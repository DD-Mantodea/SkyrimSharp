#include "runtime.h"
#include "../prisma/prisma.h"
#include "../utils.h"
#include "../internal/log.h"
#include "../internal/Form.h"
#include "../internal/event.h"
#include "../internal/input.h"
#include "../internal/oselector.h"
#include "../internal/otalkduringsex.h"
#include "../internal/addresslib.h"
#include "../game/player.h"
#include "../game/form.h"
#include "../game/actor.h"

using namespace SharpInternal::OSelector;

namespace Runtime
{
    using string_t = std::basic_string<char_t>;

    const string_t root(L"./Data/SKSE/Plugins/SkyrimSharp/");
    const string_t config_path = root + L"SkyrimSharpLoader.runtimeconfig.json";

    hostfxr_initialize_for_runtime_config_fn init_fptr;
    hostfxr_get_runtime_delegate_fn get_delegate_fptr;
    hostfxr_close_fn close_fptr;

    load_assembly_and_get_function_pointer_fn load_assembly_and_get_function_pointer;

    component_entry_point_fn set_internal_call_fptr;

    void* load_library(const char_t* path)
    {
		HMODULE h = ::LoadLibraryW(path);
        assert(h != nullptr);
		return (void*)h;
    }

    void* get_export(void* h, const char* name)
    {
        void* f = ::GetProcAddress((HMODULE)h, name);
		assert(f != nullptr);
        return f;
    }

    bool load_hostfxr()
	{
        char_t buffer[MAX_PATH];
        size_t buffer_size = sizeof(buffer) / sizeof(char_t);
        int rc = get_hostfxr_path(buffer, &buffer_size, nullptr);

        logs::debug("hostfxr path is {}", Utils::to_string(buffer));

        if (rc != 0)
            return false;

        // Load hostfxr and get desired exports
        void* lib = load_library(buffer);

        logs::debug("successfully load library.");

        init_fptr = (hostfxr_initialize_for_runtime_config_fn)get_export(lib, "hostfxr_initialize_for_runtime_config");
        get_delegate_fptr = (hostfxr_get_runtime_delegate_fn)get_export(lib, "hostfxr_get_runtime_delegate");
        close_fptr = (hostfxr_close_fn)get_export(lib, "hostfxr_close");

        return (init_fptr && get_delegate_fptr && close_fptr);
	}

    int get_function_pointer(const char_t* assembly_path, const char_t* type_name, const char_t* method_name, const char_t* delegate_type_name, void* reserved, void** delegate)
    {
        if (!load_assembly_and_get_function_pointer)
            return -1;

        return load_assembly_and_get_function_pointer(assembly_path, type_name, method_name, delegate_type_name, reserved, delegate);
    }

	load_assembly_and_get_function_pointer_fn get_dotnet_load_assembly(const char_t* cfg_path)
    {
        // Load .NET Core
        void* ptr = nullptr;
        hostfxr_handle cxt = nullptr;
        int rc = init_fptr(cfg_path, nullptr, &cxt);
        if (rc != 0 || cxt == nullptr)
        {
            logs::critical("hostfxr init failed: {}", rc);
            close_fptr(cxt);
            return nullptr;
        }

        // Get the load assembly function pointer
        rc = get_delegate_fptr(
            cxt,
            hdt_load_assembly_and_get_function_pointer,
            &ptr);
        if (rc != 0 || ptr == nullptr)
            logs::critical("get_delegate_fptr failed: {}", rc);

        close_fptr(cxt);
        return (load_assembly_and_get_function_pointer_fn)ptr;
    }

    bool set_internal_call(InternalCallArgs* args, int size)
    {
        if (set_internal_call_fptr == nullptr)
            return false;

		return set_internal_call_fptr(args, size) == 0;
    }

    void initialize()
    {
        if (!load_hostfxr())
        {
            logs::critical("Load Hostfxr failed.");

            return;
        }

        load_assembly_and_get_function_pointer = get_dotnet_load_assembly(config_path.c_str());

		component_entry_point_fn initialize_function_pointer = nullptr;

        int rc = get_function_pointer(
            L"./Data/SKSE/Plugins/SkyrimSharp/SkyrimSharpLoader.dll",
            L"SkyrimSharpLoader.Runtime.Core, SkyrimSharpLoader",
            L"SetInternalCall",
            nullptr,
            nullptr,
			(void**)&set_internal_call_fptr
        );

        SharpInternal::Log::set_internal();

        SharpInternal::Form::set_internal();

        SharpInternal::Event::set_internal();

        SharpInternal::Input::set_internal();

        SharpInternal::AddressLib::set_internal();

        SharpInternal::OSelector::set_internal();

        Game::Player::set_internal();

        Game::Actor::set_internal();

        Game::Form::set_internal();

		Prisma::set_internal();

        rc = get_function_pointer(
            L"./Data/SKSE/Plugins/SkyrimSharp/SkyrimSharpLoader.dll",
            L"SkyrimSharpLoader.Runtime.Core, SkyrimSharpLoader",
            L"Initialize",
            nullptr,
            nullptr,
			(void**)&initialize_function_pointer
        );

		initialize_function_pointer(nullptr, 0);
    }

    void load_contents()
    {
        component_entry_point_fn load_ptr = nullptr;

        auto rc = get_function_pointer(
            L"./Data/SKSE/Plugins/SkyrimSharp/SkyrimSharpLoader.dll",
            L"SkyrimSharpLoader.Runtime.Core, SkyrimSharpLoader",
            L"LoadContents",
            nullptr,
            nullptr,
            (void**)&load_ptr
        );

        load_ptr(nullptr, 0);

        logs::info("Successfully load contents.");
    }
}