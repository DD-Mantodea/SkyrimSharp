#include "JsFragment.h"

namespace SharpInternal::JsFragment
{
	class TopicInfoSink : public RE::BSTEventSink<RE::TESTopicInfoEvent>
	{
	public:
		static TopicInfoSink* GetSingleton()
		{
			static TopicInfoSink singleton;

			return std::addressof(singleton);
		}

		RE::BSEventNotifyControl ProcessEvent(const RE::TESTopicInfoEvent* a_event, RE::BSTEventSource<RE::TESTopicInfoEvent>* a_eventSource) override
		{
			if (!a_event)
				return RE::BSEventNotifyControl::kContinue;

			SharpInternal::Event::EventManager::GetSingleton()->Send(
				kTopicInfoEventname,
				const_cast<RE::TESTopicInfoEvent*>(a_event),
				sizeof(RE::TESTopicInfoEvent)
			);

			return RE::BSEventNotifyControl::kContinue;
		}
	};

	void AddListener()
	{
		auto holder = RE::ScriptEventSourceHolder::GetSingleton();

		if (!holder)
			return;

		holder->AddEventSink<RE::TESTopicInfoEvent>(TopicInfoSink::GetSingleton());

		logs::info("Successfully add JsFragment listener.");
	}
}