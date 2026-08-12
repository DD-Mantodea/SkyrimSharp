#pragma once

#include "../utils.h"
#include "../runtime/runtime.h"

using namespace Runtime;

namespace Game::Actor
{
	inline const char_t* ActorType = L"SkyrimSharpLoader.Internal.Actor";

	void set_internal();

	inline void set_actor_call(const char_t* name, void* fn_ptr)
	{
		Runtime::InternalCallArgs args
		{
			ActorType,
			name,
			fn_ptr,
			true
		};

		set_internal_call(&args, sizeof(args));
	}
}