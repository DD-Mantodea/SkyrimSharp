#pragma once

#include "../utils.h"
#include "../runtime/runtime.h"
#include "RE/P/PlayerCharacter.h"

namespace Game::Player
{
	inline const char_t* PlayerType = L"SkyrimSharpLoader.Internal.Player";

	inline RE::PlayerCharacter* get_player()
	{
		return RE::PlayerCharacter::GetSingleton();
	}

	inline void set_player_call(const char_t* name, void* fn_ptr)
	{
		Runtime::InternalCallArgs args
		{
			PlayerType,
			name,
			fn_ptr,
			true
		};

		set_internal_call(&args, sizeof(args));
	}

	void set_internal()
	{
		set_player_call(L"_getPlayer", (void*)get_player);
	}
}