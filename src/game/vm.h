#pragma once

#include "../utils.h"
#include "../runtime/runtime.h"

using namespace RE;
using namespace RE::detail;
using namespace RE::BSScript;

namespace Game::VM
{
	inline const char_t* VMType = L"SkyrimSharpLoader.Internal.VM";

	inline void set_vm_call(const char_t* name, void* fn_ptr)
	{
		Runtime::InternalCallArgs args
		{
			VMType,
			name,
			fn_ptr,
			true
		};

		set_internal_call(&args, sizeof(args));
	}

	inline void DispatchStaticCall(const RE::BSFixedString& a_className, const RE::BSFixedString& a_fnName, IFunctionArguments* a_args, BSTSmartPointer<IStackCallbackFunctor>& a_result = *new BSTSmartPointer<IStackCallbackFunctor>())
	{
		const auto skyrimVM = RE::SkyrimVM::GetSingleton();

		auto vm = skyrimVM ? skyrimVM->impl : nullptr;

		if (vm)
		{
			vm->DispatchStaticCall(a_className, a_fnName, a_args, a_result);
		}
	}

	inline void set_internal()
	{

	}
}