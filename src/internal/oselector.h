#pragma once

#include "../utils.h"
#include "../runtime/runtime.h"

using namespace Runtime;

namespace SharpInternal::OSelector
{
	void set_internal();

	struct SelectArgs
	{
		const char_t* ID;
		const char_t* ret = new char_t[256];
	};

	const char_t* select_by_config(const char_t* ID);

	string SelectByConfig(RE::StaticFunctionTag*, string ID);
}