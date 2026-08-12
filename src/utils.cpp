#include "utils.h"

using namespace RE::BSScript;

namespace Utils
{
    std::string to_string(const wchar_t* a_wstr)
    {
        if (!a_wstr)
            return "";

        auto len = (wcslen(a_wstr) + 1) * 2;

        char* nstring = new char[len];

        size_t size = 0;

        wcstombs_s(&size, nstring, len, a_wstr, _TRUNCATE);

        auto res = std::string(nstring);

        delete[]nstring;

        return res;
    }

    std::wstring to_wstring(const char* a_str)
    {
        if (!a_str)
            return L"";

        auto len = strlen(a_str) + 1;

        wchar_t* wcstring = new wchar_t[len];

        size_t size = 0;

        mbstowcs_s(&size, wcstring, len, a_str, _TRUNCATE);

        auto res = std::wstring(wcstring);

        delete[]wcstring;

        return res;
    }

    float GetDistanceSq(RE::NiPoint3 p1, RE::NiPoint3 p2)
    {
        float dx = p1.x - p2.x;

        float dy = p1.y - p2.y;

        float dz = p1.z - p2.z;

        return dx * dx + dy * dy + dz * dz;
    }

    bool IsMenuOpen()
    {
        auto ui = RE::UI::GetSingleton();

        if (!ui)
            return false;

        bool isInMenuMode = ui->GameIsPaused();

        bool isConsoleOpen = ui->IsMenuOpen(RE::Console::MENU_NAME);

        bool isCraftingOpen = ui->IsMenuOpen(RE::CraftingMenu::MENU_NAME);

        bool isDialogueOpen = ui->IsMenuOpen(RE::DialogueMenu::MENU_NAME);

        return isInMenuMode || isConsoleOpen || isCraftingOpen || isDialogueOpen;
    }

    RE::Actor* GetActorByFormID(RE::FormID formID)
    {
        auto form = RE::TESForm::LookupByID(formID);

        if (!form)
            return nullptr;

        return form->As<RE::Actor>();
    }

    const RE::TESFile* GetMod(const char* modName)
    {
        auto dataHandler = RE::TESDataHandler::GetSingleton();

        if (!dataHandler)
            return nullptr;

        auto mod = dataHandler->LookupModByName(modName);

        return mod;
    }

    RE::TESForm* GetFormByFromID(const RE::TESFile* mod, RE::FormID formID)
    {
        if (!mod)
            return nullptr;

        auto dataHandler = RE::TESDataHandler::GetSingleton();

        if (!dataHandler)
            return nullptr;

        return dataHandler->LookupForm(formID, mod->fileName);
    }

    void ForEachReferenceInRange(RE::TESObjectREFR* a_origin, float a_radius, std::function<RE::BSContainer::ForEachResult(RE::TESObjectREFR* a_ref)> a_callback)
    {
        auto tes = RE::TES::GetSingleton();

        if (!tes)
            return;

        if (a_origin && a_radius > 0)
        {
            const auto originPos = a_origin->GetPosition();

            if (tes->interiorCell)
                tes->interiorCell->ForEachReferenceInRange(originPos, a_radius, [&](RE::TESObjectREFR* a_ref) { return a_callback(a_ref); });
            else
            {
                if (const auto gridLength = tes->gridCells ? tes->gridCells->length : 0; gridLength > 0)
                {
                    const float yPlus = originPos.y + a_radius;
                    const float yMinus = originPos.y - a_radius;
                    const float xPlus = originPos.x + a_radius;
                    const float xMinus = originPos.x - a_radius;

                    std::uint32_t x = 0;
                    do {
                        std::uint32_t y = 0;
                        do {
                            if (const auto cell = tes->gridCells->GetCell(x, y); cell && cell->IsAttached()) {
                                if (const auto cellCoords = cell->GetCoordinates(); cellCoords) {
                                    const RE::NiPoint2 worldPos{ cellCoords->worldX, cellCoords->worldY };
                                    if (worldPos.x < xPlus && (worldPos.x + 4096.0f) > xMinus &&
                                        worldPos.y < yPlus && (worldPos.y + 4096.0f) > yMinus) {
                                        cell->ForEachReferenceInRange(
                                            originPos, a_radius,
                                            [&](RE::TESObjectREFR* a_ref) { return a_callback(a_ref); });
                                    }
                                }
                            }
                            ++y;
                        } while (y < gridLength);
                        ++x;
                    } while (x < gridLength);
                }
            }
        }
    }

    vector<RE::Actor*> GetActorsInRangeV2(RE::TESObjectREFR* center, float range, bool includeCenter, bool includePlayer, bool ostimActorsOnly, RE::BGSPerk* condition)
    {
        vector<RE::Actor*> actors;

        ForEachReferenceInRange(center, range,
            [&actors, center, includeCenter, includePlayer, ostimActorsOnly, condition](RE::TESObjectREFR* ref)
            {
                if (!ref->Is(RE::Actor::FORMTYPE))
                    return RE::BSContainer::ForEachResult::kContinue;

                auto actor = ref->As<RE::Actor>();

                if (!includeCenter && actor == center)
                    return RE::BSContainer::ForEachResult::kContinue;

                if (!includePlayer && actor->IsPlayerRef())
                    return RE::BSContainer::ForEachResult::kContinue;

                if (condition && !condition->perkConditions.IsTrue(actor, actor))
                    return RE::BSContainer::ForEachResult::kContinue;

                actors.push_back(actor);

                return RE::BSContainer::ForEachResult::kContinue;
            }
        );

        return actors;
    }

    bool TryCallAs(RE::TESForm* form, const char* papyrusType, const char* functionName, RE::BSScript::IFunctionArguments* arguments, BSTSmartPointer<IStackCallbackFunctor> result)
    {
        auto vm = RE::BSScript::Internal::VirtualMachine::GetSingleton();

        if (!vm)
            return false;

        RE::BSTSmartPointer<RE::BSScript::ObjectTypeInfo> typeInfo;

        if (vm->GetScriptObjectType(papyrusType, typeInfo))
        {
            auto vmHandle = vm->handlePolicy->GetHandleForObject(form->FORMTYPE, form);

            if (!vmHandle)
                return false;

            if (!arguments)
                arguments = RE::MakeFunctionArguments();

            RE::BSTSmartPointer<RE::BSScript::Object> scriptObject;

            if (vm->FindBoundObject(vmHandle, papyrusType, scriptObject))
                return vm->DispatchMethodCall(scriptObject, functionName, arguments, result);
        }
    }

    vector<RE::TESTopicInfo*> GetAvailableDialogues(RE::Actor* a_speaker)
    {
        vector<RE::TESTopicInfo*> infos;
        
        auto player = RE::PlayerCharacter::GetSingleton();

        if (!player || !a_speaker)
            return infos;

        auto dataHandler = RE::TESDataHandler::GetSingleton();

        auto& topics = dataHandler->GetFormArray<RE::TESTopic>();

        for (auto topic : topics)
        {
            if (!topic)
                continue;

            for (auto i = 0; i < topic->numTopicInfos; i++)
            {
                auto info = topic->topicInfos[i];

                if (!info)
                    continue;

                if (info->objConditions.IsTrue(a_speaker, player))
                    infos.push_back(info);
            }
        }

        return infos;
    }
}