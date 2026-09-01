#include "Event.h"
#include "Addresslib.h"

namespace SharpInternal::AddressLib
{
	size_t id2offset(uint64_t id)
	{
		return id ? REL::IDDatabase::get().id2offset(id) : 0;
	}

	uintptr_t base()
	{
		return REL::Module::get().base();
	}

	const char_t* AddrType = L"SkyrimSharpLoader.Internal.AddressLib";

	void set_addr_call(const char_t* name, void* fn_ptr)
	{
		Runtime::InternalCallArgs args
		{
			AddrType,
			name,
			fn_ptr,
			true
		};

		set_internal_call(&args, sizeof(args));
	}

	void set_internal()
	{
		set_addr_call(L"_id2offset", (void*)id2offset);

		set_addr_call(L"_base", (void*)base);
	}
}