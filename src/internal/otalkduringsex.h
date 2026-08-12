#pragma once

#include "../utils.h"
#include "../runtime/runtime.h"

using namespace Runtime;

namespace SharpInternal::OTalkDuringSex
{
	static bool Disabled;

	void AddListener();

	class SexDialogInputSink : public RE::BSTEventSink<RE::InputEvent*>
	{
	public:
		static SexDialogInputSink* GetSingleton();

		RE::BSEventNotifyControl ProcessEvent(RE::InputEvent* const* event_p, RE::BSTEventSource<RE::InputEvent*>* eventSource_p) override;
	};

	void DisableTillThreadEnd(RE::StaticFunctionTag*);

	inline static void Register(RE::BSScript::Internal::VirtualMachine* a_vm)
	{
		a_vm->RegisterFunction("DisableTillThreadEnd", "OTalkDuringSex", DisableTillThreadEnd);
	}
}