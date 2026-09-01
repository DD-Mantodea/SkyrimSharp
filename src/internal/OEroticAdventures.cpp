#include "OEroticAdventures.h"

namespace SharpInternal::OEroticAdventures
{
	void StartKeyScene(RE::StaticFunctionTag*, vector<RE::Actor*> actors, string listenerID, string sceneID, RE::TESObjectREFR* furniture)
	{
		auto threadAPI = ThreadAPI::GetSingleton();

		auto builder = threadAPI->CreateBuilder(actors);

		builder->noPlayerControl();

		builder->noUndressing();

		auto metadata = format("{},EroticAdventures,ChangeStage", listenerID);

		builder->setMetadataCSV(metadata.c_str());

		builder->setStartingNode(sceneID.c_str());

		if (furniture)
			builder->setFurniture((void*)furniture);

		builder->start();
	}

	void StartDailyScene(RE::StaticFunctionTag*, vector<RE::Actor*> actors, string listenerID, string sceneID, int type, RE::TESObjectREFR* furniture)
	{
		auto threadAPI = ThreadAPI::GetSingleton();

		auto builder = threadAPI->CreateBuilder(actors);

		builder->noPlayerControl();

		builder->noUndressing();

		auto metadata = format("{},EroticAdventures,Daily,{}", listenerID, type);

		builder->setMetadataCSV(metadata.c_str());

		builder->setStartingNode(sceneID.c_str());

		if (furniture)
			builder->setFurniture((void*)furniture);

		builder->start();
	}
}