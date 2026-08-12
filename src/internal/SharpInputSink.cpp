#include "RE/Skyrim.h"
#include "SKSE/SKSE.h"
#include "SharpInputSink.h"
#include "input.h"

namespace SharpInternal::Input
{
	SharpInputSink* SharpInputSink::GetSingleton()
	{
		static SharpInputSink singleton;

		return &singleton;
	}

	RE::BSEventNotifyControl SharpInputSink::ProcessEvent(RE::InputEvent* const* event_p, RE::BSTEventSource<RE::InputEvent*>* eventSource_p)
	{
		if (!event_p || !eventSource_p)
			return RE::BSEventNotifyControl::kContinue;

		for (auto event = *event_p; event; event = event->next)
		{
			if (event->GetEventType() == RE::INPUT_EVENT_TYPE::kButton)
			{
				auto buttonEvent = static_cast<RE::ButtonEvent*>(event);

				if (!buttonEvent)
					continue;

				button_event(buttonEvent);
			}
		}

		return RE::BSEventNotifyControl::kContinue;
	}
}