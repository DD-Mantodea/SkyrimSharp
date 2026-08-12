#include "othread.h"

namespace OSharp::Thread
{
	ThreadAPI::ThreadAPI() { }

	void ThreadAPI::Initialize(InterfaceMap* map)
	{
		_threadInterface = static_cast<ThreadInterface*>(map->queryInterface(ThreadInterface::NAME));

		if (!_threadInterface)
			return;
	}

	SharpThreadEventListener* ThreadAPI::CreateListener(Delegate delegate)
	{
		return new SharpThreadEventListener(delegate);
	}

	void ThreadAPI::RegisterThreadStartListener(ThreadEventListener* listener)
	{
		if (!_threadInterface || !listener)
			return;

		_threadInterface->registerThreadStartListener(listener);
	}

	void ThreadAPI::RegisterNodeChangedListener(ThreadEventListener* listener)
	{
		if (!_threadInterface || !listener)
			return;

		_threadInterface->registerNodeChangedListener(listener);
	}


	void ThreadAPI::RegisterThreadStopListener(ThreadEventListener* listener)
	{
		if (!_threadInterface || !listener)
			return;

		_threadInterface->registerThreadStopListener(listener);
	}

	bool ThreadAPI::IsThreadValid(uint32_t threadID)
	{
		if (!_threadInterface)
			return false;

		auto thread = _threadInterface->getThread(threadID);

		return thread != nullptr;
	}

	uint32_t ThreadAPI::GetActorPosition(uint32_t threadID, uint32_t formID)
	{
		if (!_threadInterface || !_threadInterface->getThread(threadID))
			return false;

		auto thread = _threadInterface->getThread(threadID);

		auto count = thread->getActorCount();

		for (auto i = 0; i < count; i++)
		{
			auto actor = static_cast<RE::Actor*>(thread->getActor(i)->getGameActor());

			if (actor->formID == formID)
				return i;
		}

		return -1;
	}

	uint32_t ThreadAPI::GetActorPosition(OStim::Thread* thread, uint32_t formID)
	{
		if (!thread)
			return -1;

		auto count = thread->getActorCount();

		for (auto i = 0; i < count; i++)
		{
			auto actor = static_cast<RE::Actor*>(thread->getActor(i)->getGameActor());

			if (actor->formID == formID)
				return i;
		}

		return -1;
	}

	vector<ThreadActor*> ThreadAPI::GetThreadActors(uint32_t threadID)
	{
		auto result = vector<ThreadActor*>();

		if (!_threadInterface || !_threadInterface->getThread(threadID))
			return result;

		auto thread = _threadInterface->getThread(threadID);

		auto count = thread->getActorCount();

		for (auto i = 0; i < count; i++)
			result.push_back(thread->getActor(i));

		return result;
	}

	vector<ThreadActor*> ThreadAPI::GetThreadActors(OStim::Thread* thread)
	{
		auto result = vector<ThreadActor*>();

		if (!thread)
			return result;

		auto count = thread->getActorCount();

		for (auto i = 0; i < count; i++)
			result.push_back(thread->getActor(i));

		return result;
	}

	vector<RE::Actor*> ThreadAPI::GetActors(uint32_t threadID)
	{
		auto result = vector<RE::Actor*>();

		if (!_threadInterface || !_threadInterface->getThread(threadID))
			return result;

		auto thread = _threadInterface->getThread(threadID);

		auto count = thread->getActorCount();

		for (auto i = 0; i < count; i++)
			result.push_back(static_cast<RE::Actor*>(thread->getActor(i)->getGameActor()));

		return result;
	}

	vector<RE::Actor*> ThreadAPI::GetActors(OStim::Thread* thread)
	{
		auto result = vector<RE::Actor*>();

		if (!thread)
			return result;

		auto count = thread->getActorCount();

		for (auto i = 0; i < count; i++)
			result.push_back(static_cast<RE::Actor*>(thread->getActor(i)->getGameActor()));

		return result;
	}

	vector<Action*> ThreadAPI::GetActions(uint32_t threadID)
	{
		auto result = vector<Action*>();

		if (!_threadInterface || !_threadInterface->getThread(threadID))
			return result;

		auto thread = _threadInterface->getThread(threadID);

		auto node = thread->getCurrentNode();

		auto count = node->getActionCount();

		for (auto i = 0; i < count; i++)
			result.push_back(node->getAction(i));

		return result;
	}

	vector<Action*> ThreadAPI::GetActions(OStim::Thread* thread)
	{
		auto result = vector<Action*>();

		if (!thread)
			return result;

		auto node = thread->getCurrentNode();

		auto count = node->getActionCount();

		for (auto i = 0; i < count; i++)
			result.push_back(node->getAction(i));

		return result;
	}

	void SharpThreadEventListener::listen(OStim::Thread* thread)
	{
		if (!_delegate || !thread)
			return;

		_delegate(thread);
	}
}