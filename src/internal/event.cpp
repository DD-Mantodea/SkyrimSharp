#include "event.h"

namespace SharpInternal::Event
{
	void EventManager::Register(EventHandler handler, const char* eventName)
	{
		if (!handler)
			return;

		auto index = eventName ? string(eventName) : "";

		if (!_handlers.contains(index))
			_handlers[index] = vector<EventHandler*>();

		_handlers[index].push_back(handler);
	}

	void EventManager::Unregister(EventHandler handler, const char* eventName)
	{
		if (!handler)
			return;

		if (!eventName)
		{
			auto it = _handlers.begin();

			while (it != _handlers.end())
			{
				auto& vec = it->second;

				vec.erase(
					remove(vec.begin(), vec.end(), handler),
					vec.end()
				);

				if (vec.empty())
					it = _handlers.erase(it);
				else
					++it;
			}
		}
		else
		{
			auto index = string(eventName);

			auto it = _handlers.find(index);

			if (it != _handlers.end())
			{
				auto& vec = it->second;

				vec.erase(
					remove(vec.begin(), vec.end(), handler),
					vec.end()
				);
			}
		}
	}

	void EventManager::Send(const char* eventName, void* args, int32_t sizeBytes)
	{
		auto index = eventName ? string(eventName) : "";

		if (index != "" && _handlers.contains(""))
			for (auto handler : _handlers[""])
				handler(eventName, args, sizeBytes);

		auto it = _handlers.find(index);

		if (it != _handlers.end())
		{
			auto& vec = it->second;

			for (auto handler : vec)
				if (handler)
					handler(eventName, args, sizeBytes);
		}
	}

	const char_t* EventType = L"SkyrimSharpLoader.Internal.EventManager";

	void set_event_call(const char_t* name, void* fn_ptr)
	{
		Runtime::InternalCallArgs args
		{
			EventType,
			name,
			fn_ptr,
			true
		};

		set_internal_call(&args, sizeof(args));
	}

	void register_event(EventHandler handler, const char* eventName = nullptr)
	{
		auto manager = EventManager::GetSingleton();

		if (!manager)
			return;

		manager->Register(handler, eventName);
	}

	void unregister_event(EventHandler handler, const char* eventName = nullptr)
	{
		auto manager = EventManager::GetSingleton();

		if (!manager)
			return;

		manager->Unregister(handler);
	}

	void send_event(const char* eventName, void* args, int32_t sizeBytes)
	{
		auto manager = EventManager::GetSingleton();

		if (!manager)
			return;

		manager->Send(eventName, args, sizeBytes);
	}

	void set_internal()
	{
		set_event_call(L"_register", (void*)register_event);

		set_event_call(L"_unregister", (void*)unregister_event);

		set_event_call(L"_send", (void*)send_event);
	}
}