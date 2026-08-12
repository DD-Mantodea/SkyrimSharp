#pragma once

#include "internal/log.h"
#include <vector>

using namespace std;
using namespace RE;

namespace Utils
{
    template <class T>
    class Singleton
    {
    public:
        Singleton() = default;
        Singleton(const Singleton&) = delete;
        Singleton(Singleton&&) = delete;

        Singleton& operator=(const Singleton&) = delete;
        Singleton& operator=(Singleton&&) = delete;

        ~Singleton() = default;

        static T* GetSingleton() noexcept {
            static T singleton;

            return std::addressof(singleton);
        }
    };

    std::string to_string(const wchar_t* a_wstr);

    std::wstring to_wstring(const char* a_str);

    float GetDistanceSq(RE::NiPoint3 p1, RE::NiPoint3 p2);

    bool IsMenuOpen();

    RE::Actor* GetActorByFormID(RE::FormID formID);

    const RE::TESFile* GetMod(const char* modName);

    RE::TESForm* GetFormByFromID(const RE::TESFile* mod, RE::FormID formID);

    void ForEachReferenceInRange(RE::TESObjectREFR* a_origin, float a_radius, std::function<RE::BSContainer::ForEachResult(RE::TESObjectREFR* a_ref)> a_callback);

    vector<RE::Actor*> GetActorsInRangeV2(RE::TESObjectREFR* center, float range, bool includeCenter, bool includePlayer, bool ostimActorsOnly, RE::BGSPerk* condition);

    bool TryCallAs(RE::TESForm* form, const char* papyrusType, const char* functionName, RE::BSScript::IFunctionArguments* arguments = nullptr, BSTSmartPointer<BSScript::IStackCallbackFunctor> result = nullptr);

    vector<RE::TESTopicInfo*> GetAvailableDialogues(RE::Actor* a_speaker);
}