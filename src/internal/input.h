#pragma once

#include "../utils.h"
#include "../runtime/runtime.h"

using namespace Runtime;

namespace SharpInternal::Input
{
    inline const char_t* InputType = L"SkyrimSharpLoader.Internal.Input";

    void set_internal();

    struct ButtonEventArgs
    {
        int keycode;

        float heldDuration;

        bool isPressed;

        bool isRepeating;

        bool isDown;

        bool isHeld;

        bool isUp;
    };

    void button_event(RE::ButtonEvent* event);
}