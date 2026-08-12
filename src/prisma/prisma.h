#pragma once

#include "runtime/runtime.h"
#include "PrismaUI_API.h"
#include "internal/event.h"

using namespace Runtime;
using namespace SharpInternal::Event;

namespace Prisma
{
	inline PRISMA_UI_API::IVPrismaUI1* PrismaUI = nullptr;

	struct CreateViewArgs
	{
		uint64_t View;

		const char* Name;
	};

	void InitializeUI();

	void RegisterCreateView(EventHandler handler);

	inline void load_api()
	{
		PrismaUI = static_cast<PRISMA_UI_API::IVPrismaUI1*>(
			PRISMA_UI_API::RequestPluginAPI(PRISMA_UI_API::InterfaceVersion::V2)
			);

		if (!PrismaUI)
		{
			logs::error("Failed to initialize PrismaUI API.");
			return;
		}

		logs::info("Successfully initialize PrismaUI API.");
	}

	inline const char_t* PrismaType = L"SkyrimSharpLoader.Compat.Prisma.Prisma";

	inline void set_prisma_call(const char_t* name, void* fn_ptr)
	{
		Runtime::InternalCallArgs args
		{
			PrismaType,
			name,
			fn_ptr,
			true
		};

		set_internal_call(&args, sizeof(args));
	}

	inline PrismaView create_view(const char* htmlPath, PRISMA_UI_API::OnDomReadyCallback callback = nullptr)
	{
		if (!PrismaUI)
			return 0;

		return PrismaUI->CreateView(htmlPath, callback);
	}

	inline void register_js_listener(PrismaView view, const char* functionName, PRISMA_UI_API::JSListenerCallback callback)
	{
		if (!PrismaUI)
			return;

		PrismaUI->RegisterJSListener(view, functionName, callback);
	}

	inline void invoke(PrismaView view, const char* script, PRISMA_UI_API::JSCallback callback = nullptr)
	{
		if (!PrismaUI)
			return;

		PrismaUI->Invoke(view, script, callback);
	}

	inline void focus(PrismaView view, bool pauseGame = false, bool disableFocusMenu = false)
	{
		if (!PrismaUI)
			return;

		PrismaUI->Focus(view, pauseGame, disableFocusMenu);
	}

	inline void unfocus(PrismaView view)
	{
		if (!PrismaUI)
			return;

		PrismaUI->Unfocus(view);
	}

	inline void show(PrismaView view)
	{
		if (!PrismaUI)
			return;

		PrismaUI->Show(view);
	}

	inline void hide(PrismaView view)
	{
		if (!PrismaUI)
			return;

		PrismaUI->Hide(view);
	}

	void set_internal();
}