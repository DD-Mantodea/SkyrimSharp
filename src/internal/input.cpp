#include "input.h"

namespace SharpInternal::Input
{
    component_entry_point_fn button_event_pointer;

	void set_internal()
    {
        int rc = get_function_pointer(
            L"./Data/SKSE/Plugins/SkyrimSharp/SkyrimSharpLoader.dll",
            L"SkyrimSharpLoader.Internal.Input, SkyrimSharpLoader",
            L"ButtonEvent",
            nullptr,
            nullptr,
            (void**)&button_event_pointer
        );
    }

    void button_event(RE::ButtonEvent* event)
    {
        if (!button_event_pointer)
        {
            logs::debug("event is null");

            return;
        }

        ButtonEventArgs args
        {
            event->GetIDCode(),
            event->HeldDuration(),
            event->IsPressed(),
            event->IsRepeating(),
            event->IsDown(),
            event->IsHeld(),
            event->IsUp()
        };

        button_event_pointer(&args, sizeof(args));
    }
}