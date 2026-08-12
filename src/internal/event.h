#pragma once

#include <map>
#include "../utils.h"
#include "../runtime/runtime.h"

using namespace std;

namespace SharpInternal::Event
{
	using EventHandler = void(const char* eventName, void* args, int32_t sizeBytes);

	class EventManager
	{
	public:

		static EventManager* GetSingleton()
		{
			static EventManager singleton;

			return &singleton;
		}

		void Register(EventHandler handler, const char* eventName = nullptr);

		void Unregister(EventHandler handler, const char* eventName = nullptr);

		void Send(const char* eventName, void* args, int32_t sizeBytes);

	private:
		EventManager() : _handlers() {}

		map<string, vector<EventHandler*>> _handlers;
	};

	void set_internal();
}