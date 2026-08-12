#pragma once

#include "../utils.h"
#include "../runtime/runtime.h"

namespace SharpInternal::Log
{
    void info(const wchar_t* msg);

    void infoS(string msg);

    void error(const wchar_t* msg);

    void errorS(string msg);

    void debug(const wchar_t* msg);

    void debugS(string msg);

    void set_internal();
}