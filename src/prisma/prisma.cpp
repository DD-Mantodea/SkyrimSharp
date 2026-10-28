#include "prisma.h"

namespace Prisma
{
	component_entry_point_fn initialize_ui_pointer;

	void InitializeUI()
	{
		if (!initialize_ui_pointer)
			return;

		initialize_ui_pointer(nullptr, 0);

		logs::info("Successfully initialize Prisma UI.");
	}

	void RegisterCreateView(EventHandler handler)
	{
		EventManager::GetSingleton()->Register(handler, "PrismaCreateView");
	}

	void set_internal()
	{
		set_prisma_call(L"_createView", (void*)create_view);

		set_prisma_call(L"_registerJSListener", (void*)register_js_listener);

		set_prisma_call(L"_invoke", (void*)invoke);

		set_prisma_call(L"_focus", (void*)focus);

		set_prisma_call(L"_unfocus", (void*)unfocus);

		set_prisma_call(L"_show", (void*)show);

		set_prisma_call(L"_hide", (void*)hide); 
		
		int rc = get_function_pointer(
			L"./Data/SKSE/Plugins/SkyrimSharp/SkyrimSharpLoader.dll",
			L"SkyrimSharpLoader.Compat.Prisma.Prisma, SkyrimSharpLoader",
			L"InitializeUI",
			nullptr,
			nullptr,
			(void**)&initialize_ui_pointer
		);
	}
}