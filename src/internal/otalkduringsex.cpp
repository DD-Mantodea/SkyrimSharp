#include "otalkduringsex.h"
#include "internal/log.h"
#include "ostim/thread/othread.h"
#include "prisma/prisma.h"
#include "nlohmann/json.hpp"

using namespace SharpInternal;
using namespace OSharp::Thread;

using JSON = nlohmann::json;

namespace SharpInternal::OTalkDuringSex
{
	class OTalkThreadStartListener : public ThreadEventListener
	{
		void listen(Thread* thread) override
		{
			if (!thread->isPlayerThread())
				return;

			auto mod = Utils::GetMod("OTalkDuringSex.esp");

			if (!mod)
				return;

			auto inOstimFaction = Utils::GetFormByFromID(mod, 0x80B)->As<RE::TESFaction>();

			if (!inOstimFaction)
				return;

			auto threadApi = ThreadAPI::GetSingleton();

			if (!threadApi)
				return;

			auto actors = threadApi->GetActors(thread);

			for (auto actor : actors)
				actor->AddToFaction(inOstimFaction, 0);
		}
	};

	class OTalkNodeChangedListener : public ThreadEventListener
	{
		void listen(Thread* thread) override
		{
			if (!thread->isPlayerThread())
				return;

			auto mod = Utils::GetMod("OTalkDuringSex.esp");

			if (!mod)
				return;

			auto sexFaction = Utils::GetFormByFromID(mod, 0x80C)->As<RE::TESFaction>();

			if (!sexFaction)
				return;

			auto threadApi = ThreadAPI::GetSingleton();

			if (!threadApi)
				return;

			auto actors = threadApi->GetActors(thread);

			auto actions = threadApi->GetActions(thread);

			for (auto actor : actors)
				actor->RemoveFromFaction(sexFaction);

			for (auto action : actions)
			{
				auto type = action->getType();

				if (type->hasTag("sexual"))
				{
					actors[action->getActor(Role::ACTOR)]->AddToFaction(sexFaction, 0);

					actors[action->getActor(Role::TARGET)]->AddToFaction(sexFaction, 0);

					actors[action->getActor(Role::PERFORMER)]->AddToFaction(sexFaction, 0);
				}
			}
		}
	};

	class OTalkThreadEndedListener : public ThreadEventListener
	{
		void listen(Thread* thread)
		{
			if (!thread->isPlayerThread())
				return;

			auto mod = Utils::GetMod("OTalkDuringSex.esp");

			if (!mod)
				return;

			auto inOstimFaction = Utils::GetFormByFromID(mod, 0x80B)->As<RE::TESFaction>();

			auto sexFaction = Utils::GetFormByFromID(mod, 0x80C)->As<RE::TESFaction>();

			if (!inOstimFaction || !sexFaction)
				return;

			auto threadApi = ThreadAPI::GetSingleton();

			if (!threadApi)
				return;

			auto actors = threadApi->GetActors(thread);

			for (auto actor : actors)
			{
				actor->RemoveFromFaction(inOstimFaction);

				actor->RemoveFromFaction(sexFaction);
			}

			Disabled = false;
		}
	};

	static uint64_t MultipleNpcTalk;

	void AddListener()
	{
		auto threadApi = ThreadAPI::GetSingleton();

		threadApi->RegisterThreadStartListener(new OTalkThreadStartListener);

		threadApi->RegisterNodeChangedListener(new OTalkNodeChangedListener);

		threadApi->RegisterThreadStopListener(new OTalkThreadEndedListener);

		Prisma::RegisterCreateView([](const char* eventName, void* args, int32_t sizeBytes) {
			auto cArgs = static_cast<Prisma::CreateViewArgs*>(args);

			if (string_view(cArgs->Name) == string_view("MultipleNpcTalk"))
				MultipleNpcTalk = cArgs->View;
		});
	}

	SexDialogInputSink* SexDialogInputSink::GetSingleton()
	{
		static SexDialogInputSink singleton;

		return &singleton;
	}

	RE::BSEventNotifyControl SexDialogInputSink::ProcessEvent(RE::InputEvent* const* event_p, RE::BSTEventSource<RE::InputEvent*>* eventSource_p)
	{
		if (!event_p || !eventSource_p || Disabled)
			return RE::BSEventNotifyControl::kContinue;

		for (auto event = *event_p; event; event = event->next)
		{
			if (event->GetEventType() == RE::INPUT_EVENT_TYPE::kButton)
			{
				auto buttonEvent = static_cast<RE::ButtonEvent*>(event);

				if (!buttonEvent)
					continue;

				auto mod = Utils::GetMod("OTalkDuringSex.esp");

				if (!mod)
					return RE::BSEventNotifyControl::kContinue;

				auto sameSceneOnly = Utils::GetFormByFromID(mod, 0x804)->As<RE::TESGlobal>();

				auto enableKey = Utils::GetFormByFromID(mod, 0x809)->As<RE::TESGlobal>();

				if (!sameSceneOnly || !enableKey)
					return RE::BSEventNotifyControl::kContinue;

				if (buttonEvent->GetIDCode() == enableKey->value && buttonEvent->IsUp())
				{
					auto player = RE::PlayerCharacter::GetSingleton();

					if (!player || !player->parentCell)
						return RE::BSEventNotifyControl::kContinue;

					auto threadApi = ThreadAPI::GetSingleton();

					if (!threadApi || !threadApi->IsThreadValid(0))
						return RE::BSEventNotifyControl::kContinue;

					auto actors = threadApi->GetActors(static_cast<uint32_t>(0));

					erase_if(actors, [](Actor* actor) {
						return actor->IsPlayerRef();
					});

					if (actors.size() == 0 || Utils::IsMenuOpen())
						return RE::BSEventNotifyControl::kContinue;

					if (sameSceneOnly->value == 1)
					{
						if (actors.size() == 1)
						{
							auto target = actors[0];

							target->ActivateRef(player, 0, target->GetBaseObject(), 1, false);

							return RE::BSEventNotifyControl::kStop;
						}
					}
					else
					{
						actors = Utils::GetActorsInRangeV2(player, 1.5 * 100, false, false, false, nullptr);

						if (actors.size() == 0)
							return RE::BSEventNotifyControl::kContinue;

						if (actors.size() == 1)
						{
							actors[0]->ActivateRef(player, 0, actors[0]->GetBaseObject(), 1, false);

							return RE::BSEventNotifyControl::kStop;
						}
					}

					erase_if(actors, [](Actor* actor) {
						return actor->IsPlayerRef() || actor->IsDead() || actor->IsDisabled() || !actor->HasKeywordString("ActorTypeNPC");
					});

					JSON actorArray = JSON::array();

					for (auto actor : actors)
					{
						JSON j = JSON::object();

						j["name"] = actor->GetDisplayFullName();

						j["ptr"] = (uint64_t)actor;

						actorArray.push_back(j);
					}

					Prisma::invoke(MultipleNpcTalk, ("makeNameList('" + actorArray.dump() + "')").c_str());

					Prisma::show(MultipleNpcTalk);

					Prisma::focus(MultipleNpcTalk, true);

					return RE::BSEventNotifyControl::kStop;
				}
			}
		}

		return BSEventNotifyControl::kContinue;
	}

	void DisableTillThreadEnd(RE::StaticFunctionTag*)
	{
		Disabled = true;
	}
}