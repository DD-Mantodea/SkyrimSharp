#pragma once

#include "ostim/thread/othread.h"

using namespace std;
using namespace OSharp::Thread;

namespace SharpInternal::OEroticAdventures
{
	void StartKeyScene(RE::StaticFunctionTag*, vector<RE::Actor*> actors, string listenerID, string sceneID, RE::TESObjectREFR* furniture = nullptr);

	void StartDailyScene(RE::StaticFunctionTag*, vector<RE::Actor*> actors, string listenerID, string sceneID, int type, RE::TESObjectREFR* furniture = nullptr);

	void StartLieOnBedScene(RE::StaticFunctionTag*, vector<RE::Actor*> actors, string listenerID, RE::TESObjectREFR* bed);

	template <class F>
	inline static void RegisterFunction(RE::BSScript::Internal::VirtualMachine* vm, string_view funcName, F callback)
	{
		vm->RegisterFunction(funcName, "OEroticAdventures", callback);
	}

	inline static void Register(RE::BSScript::Internal::VirtualMachine* a_vm)
	{
		RegisterFunction(a_vm, "StartKeyScene", StartKeyScene);
		RegisterFunction(a_vm, "StartDailyScene", StartDailyScene);
	}
}