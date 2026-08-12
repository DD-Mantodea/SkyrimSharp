#pragma once

#include "../utils.h"
#include "../runtime/runtime.h"

namespace Game::Form
{
	inline const char_t* FormType = L"SkyrimSharpLoader.Internal.Form";

	inline void set_form_call(const char_t* name, void* fn_ptr)
	{
		Runtime::InternalCallArgs args
		{
			FormType,
			name,
			fn_ptr,
			true
		};

		set_internal_call(&args, sizeof(args));
	}

	void set_internal()
	{

	}
}