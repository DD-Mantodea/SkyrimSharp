#pragma once

#include "ostim/include/InterfaceMap.h"
#include "ostim/include/Threading/ThreadInterface.h"
#include "ostim/include/Threading/Thread.h"
#include "utils.h"
#include <vector>

using namespace std;
using namespace OStim;

namespace OSharp::Thread
{
	class SharpThreadEventListener;

	using Delegate = void(*)(OStim::Thread*);

	class ThreadAPI : public Utils::Singleton<ThreadAPI>
	{
	public:
		ThreadAPI();

		void Initialize(OStim::InterfaceMap* map);

		virtual SharpThreadEventListener* CreateListener(Delegate delegate);

		virtual void RegisterThreadStartListener(ThreadEventListener* listener);

		virtual void RegisterNodeChangedListener(ThreadEventListener* listener);

		virtual void RegisterThreadStopListener(ThreadEventListener* listener);

		virtual bool IsThreadValid(uint32_t threadID);

		virtual uint32_t GetActorPosition(uint32_t threadID, uint32_t formID);

		virtual uint32_t GetActorPosition(OStim::Thread* thread, uint32_t formID);

		virtual vector<ThreadActor*> GetThreadActors(uint32_t threadID);

		virtual vector<ThreadActor*> GetThreadActors(OStim::Thread* thread);

		virtual vector<RE::Actor*> GetActors(uint32_t threadID);

		virtual vector<RE::Actor*> GetActors(OStim::Thread* thread);

		virtual vector<Action*> GetActions(uint32_t threadID);

		virtual vector<Action*> GetActions(OStim::Thread* thread);

		virtual ThreadBuilder* CreateBuilder(vector<RE::Actor*> actors);

	private:
		OStim::ThreadInterface* _threadInterface = nullptr;
	};

	class SharpThreadEventListener : public ThreadEventListener
	{
	public:
		SharpThreadEventListener(Delegate delegate) : _delegate(delegate) {}

		void listen(OStim::Thread* thread) override;

	private:
		Delegate _delegate;
	};
}