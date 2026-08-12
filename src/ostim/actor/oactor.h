#pragma once

#include "../thread/othread.h"
#include "utils.h"

namespace OSharp::Actor
{
	class ActorAPI : public Utils::Singleton<ActorAPI>
	{
	public:
		ActorAPI();

		virtual bool InThread(uint32_t threadID, uint32_t formID);
	};
}