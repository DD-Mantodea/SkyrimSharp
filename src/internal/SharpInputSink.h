#pragma once

namespace SharpInternal::Input
{
    class SharpInputSink : public RE::BSTEventSink<RE::InputEvent*>
    {
    public:
        static SharpInputSink* GetSingleton();

        RE::BSEventNotifyControl ProcessEvent(RE::InputEvent* const* event_p, RE::BSTEventSource<RE::InputEvent*>* eventSource_p) override;
    };
}