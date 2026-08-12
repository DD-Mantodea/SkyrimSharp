#pragma once
#include "nethost.h"
#include "hostfxr.h"
#include "coreclr_delegates.h"
#include <iostream>

using namespace std;

namespace Runtime
{
	void* load_library(const char_t* path);

	void* get_export(void* h, const char* name);

	bool load_hostfxr();

	int get_function_pointer(const char_t* assembly_path, const char_t* type_name, const char_t* method_name, const char_t* delegate_type_name, void* reserved, void** delegate);

	load_assembly_and_get_function_pointer_fn get_dotnet_load_assembly(const char_t* config_path);

	void initialize();

	void load_contents();

	struct InternalCallArgs
	{
		const char_t* type;

		const char_t* name;

		void* fn_ptr;

		bool non_public = false;
	};

	bool set_internal_call(InternalCallArgs* args, int size);
}