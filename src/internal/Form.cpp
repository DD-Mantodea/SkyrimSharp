#include "Form.h"

namespace SharpInternal::Form
{
	const char_t* FormType = L"SkyrimSharpLoader.Internal.Form";

	TESForm* lookup_by_id(uint32_t a_formID)
	{
		return RE::TESForm::LookupByID(a_formID);
	}

	TESForm* lookup_by_editor_id(const char* a_editorID)
	{
		return RE::TESForm::LookupByEditorID(std::string_view(a_editorID));
	}

	TESFile* lookup_plugin_by_id(uint32_t a_formID)
	{
		auto dh = RE::TESDataHandler::GetSingleton();

		auto idx = a_formID >> 24;

		if (idx == 0xFE)
		{
			auto light = static_cast<uint16_t>((a_formID >> 12) & 0xFFF);

			if (auto f = dh->LookupLoadedLightModByIndex(light))
				return const_cast<TESFile*>(f);
		}

		if (auto f = dh->LookupLoadedModByIndex(idx))
			return const_cast<TESFile*>(f);

		return nullptr;
	}

	void set_internal()
	{
		Runtime::InternalCallArgs byID{ FormType, L"_lookupByID", (void*)&lookup_by_id, true };
		set_internal_call(&byID, sizeof(byID));

		Runtime::InternalCallArgs byEDID{ FormType, L"_lookupByEditorID", (void*)&lookup_by_editor_id, true };
		set_internal_call(&byEDID, sizeof(byEDID));

		Runtime::InternalCallArgs pluginByID{ FormType, L"_lookupPluginByID", (void*)&lookup_plugin_by_id, true };
		set_internal_call(&pluginByID, sizeof(pluginByID));
	}
}