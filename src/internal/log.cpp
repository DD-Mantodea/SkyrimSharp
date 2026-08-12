#include "log.h"

namespace SharpInternal::Log
{
    inline const char_t* LogType = L"SkyrimSharpLoader.Internal.Logger";

    void info(const wchar_t* msg)
    {
        logs::info("{}", Utils::to_string(msg));
    }

    void infoS(string msg)
    {
        logs::info("{}", msg);
    }

    void error(const wchar_t* msg)
    {
        logs::error("{}", Utils::to_string(msg));
    }

    void errorS(string msg)
    {
        logs::error("{}", msg);
    }

    void debug(const wchar_t* msg)
    {
        logs::debug("{}", Utils::to_string(msg));
    }

    void debugS(string msg)
    {
        logs::debug("{}", msg);
    }

    void set_log_call(const char_t* name, void* fn_ptr)
    {
        Runtime::InternalCallArgs args
        {
            LogType,
            name,
            fn_ptr,
            true
        };

        set_internal_call(&args, sizeof(args));
    }

	void set_internal()
	{
        set_log_call(L"_debug", (void*)debug);

		set_log_call(L"_error", (void*)error);

		set_log_call(L"_info", (void*)info);
	}
}