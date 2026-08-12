#pragma once

#include "../utils.h"
#include "../runtime/runtime.h"
#include "../ostim/actor/oactor.h"
#include "../ostim/thread/othread.h"

using namespace Runtime;
using namespace OSharp::Actor;
using namespace OSharp::Thread;

namespace SharpInternal::OImmersion
{
	bool HasNPCAround(RE::StaticFunctionTag*, RE::Actor* target, float radius);

	void StopCurrentDialogue(RE::StaticFunctionTag*, RE::Actor* target);

	inline static void Register(RE::BSScript::Internal::VirtualMachine* a_vm)
	{
		a_vm->RegisterFunction("HasNPCAround", "OImmersion", HasNPCAround);

		a_vm->RegisterFunction("StopCurrentDialogue", "OImmersion", StopCurrentDialogue);
	}
}