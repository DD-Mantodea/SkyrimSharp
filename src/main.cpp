#include "internal/event.h"
#include "internal/log.h"
#include "internal/OImmersion.h"
#include "internal/OSelector.h"
#include "internal/OTalkDuringSex.h"
#include "internal/SharpInputSink.h"
#include "internal/OEroticAdventures.h"
#include "internal/JsFragment.h"
#include "ostim/thread/othread.h"
#include "ostim/include/InterfaceExchangeMessage.h"
#include "prisma/prisma.h"
#include "runtime/runtime.h"

using namespace Runtime;
using namespace SharpInternal::Input;
using namespace SharpInternal::Event;
using namespace SharpInternal::OSelector;
using namespace SharpInternal::OImmersion;
using namespace SharpInternal::OTalkDuringSex;

static void SKSEMessageHandler(SKSE::MessagingInterface::Message* a_msg)
{
	switch (a_msg->type)
	{
	case SKSE::MessagingInterface::kPostLoad:
	{
		OStim::InterfaceExchangeMessage msg;
		
		auto i = SKSE::GetMessagingInterface();

		i->Dispatch(OStim::InterfaceExchangeMessage::MESSAGE_TYPE, (void*)&msg, sizeof(OStim::InterfaceExchangeMessage*), "OStim");

		if (!msg.interfaceMap)
			return;

		OSharp::Thread::ThreadAPI::GetSingleton()->Initialize(msg.interfaceMap);

		logs::info("Successfully initialize OStim API.");

		break;
	}

	case SKSE::MessagingInterface::kDataLoaded:
	{
		Prisma::load_api();

		SharpInternal::OTalkDuringSex::AddListener();

		SharpInternal::JsFragment::AddListener();

		Prisma::InitializeUI();

		Runtime::load_contents();

		break;
	}

	case SKSE::MessagingInterface::kPostLoadGame:
	{
		auto processLists = RE::ProcessLists::GetSingleton();

		for (auto actorHandles : processLists->allProcesses)
		{
			for (const auto actorHandle : *actorHandles)
			{
				const auto actorPtr = actorHandle.get();

				auto actor = actorPtr.get();

				if (actor)
				{

				}
			}
		}


		break;
	}

	case SKSE::MessagingInterface::kInputLoaded:
	{
		auto inputDeviceManager = RE::BSInputDeviceManager::GetSingleton();

		if (inputDeviceManager)
		{
			inputDeviceManager->AddEventSink(SharpInputSink::GetSingleton());

			inputDeviceManager->AddEventSink(SexDialogInputSink::GetSingleton());
		}

		logs::info("Successfully add input listener.");

		break;
	}
	}
}

bool RegisterPapyrusFunctions(RE::BSScript::Internal::VirtualMachine* a_vm)
{
	a_vm->RegisterFunction("SelectByConfig", "OSelector", SelectByConfig);

	SharpInternal::OImmersion::Register(a_vm);

	SharpInternal::OTalkDuringSex::Register(a_vm);

	SharpInternal::OEroticAdventures::Register(a_vm);

	return true;
}

SKSEPluginLoad(const SKSE::LoadInterface* a_skse)
{
	SKSE::Init(a_skse);

	Runtime::initialize();

	auto messaging = SKSE::GetMessagingInterface();

	if (!messaging->RegisterListener("SKSE", SKSEMessageHandler)) {
		logs::error("Failed to register message listener.");
		return false;
	}

	logs::info("Register message listener successfully.");

	auto papyrus = SKSE::GetPapyrusInterface();

	if (papyrus)
		papyrus->Register(RegisterPapyrusFunctions);

	return true;
}
