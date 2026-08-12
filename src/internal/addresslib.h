#pragma once

#include "../utils.h"
#include "../runtime/runtime.h"
#include "REL/ID.h"

namespace SharpInternal::AddressLib
{
	size_t id2offset(uint64_t id);

	uintptr_t base();

	void set_internal();
}