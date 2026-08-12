#include "oimmersion.h"

using namespace SharpInternal;

namespace SharpInternal::OImmersion
{
	bool HasNPCAround(RE::StaticFunctionTag*, RE::Actor* target, float radius)
	{
		if (!target)
			return false;

		auto player = RE::PlayerCharacter::GetSingleton();

		auto center = target->GetPosition();

		auto processLists = RE::ProcessLists::GetSingleton();

		if (!processLists)
			return false;

		auto distanceSq = radius * radius;

		for (const auto& handle : processLists->highActorHandles)
		{
			auto actorPtr = handle.get();

			if (!actorPtr)
				continue;

			auto actor = actorPtr.get();

			if (!actor || actor == target || actor == player || actor->IsDead())
				continue;

			auto race = actor->GetRace();

			if (!race || !race->GetPlayable())
				continue;

			if (Utils::GetDistanceSq(actor->GetPosition(), center) < distanceSq)
				return true;
		}

		return false;
	}

	void StopCurrentDialogue(RE::StaticFunctionTag*, RE::Actor* target)
	{
		if (!target)
			return;

		auto topicManager = RE::MenuTopicManager::GetSingleton();

		if (!topicManager)
			return;

		if (!topicManager->IsCurrentSpeaker(target->GetHandle()))
			return;

		topicManager->forceGoodbye = true;
	}
}