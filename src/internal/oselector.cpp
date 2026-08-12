#include "oselector.h"

using namespace SharpInternal;

namespace SharpInternal::OSelector
{
	component_entry_point_fn select_by_config_pointer;

	void set_internal()
	{
		int rc = get_function_pointer(
            L"./Data/SKSE/Plugins/SkyrimSharp/SkyrimSharpLoader.dll",
            L"SkyrimSharpLoader.Compat.OStim.OSceneSelector.OSceneSelector, SkyrimSharpLoader",
            L"SelectByConfigPapyrus",
            nullptr,
            nullptr,
            (void**)&select_by_config_pointer
        );
	}

    const char_t* select_by_config(const char_t* ID)
    {
        if (!select_by_config_pointer)
            return L"";

        SelectArgs args
        {
            ID
        };

        select_by_config_pointer(&args, sizeof(args));

        return args.ret;
    }

    string SelectByConfig(RE::StaticFunctionTag*, string ID)
    {
        auto c_str = select_by_config(Utils::to_wstring(ID.c_str()).c_str());

        if (!c_str)
            return "";

        return Utils::to_string(c_str);
    }
}