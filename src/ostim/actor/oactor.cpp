#include "oactor.h"
#include "../thread/othread.h"

using namespace OSharp::Thread;

namespace OSharp::Actor
{
	ActorAPI::ActorAPI() { }

	bool ActorAPI::InThread(uint32_t threadID, uint32_t formID)
	{
		auto threadApi = ThreadAPI::GetSingleton();

		if (!threadApi || !threadApi->IsThreadValid(threadID))
			return false;

		return threadApi->GetActorPosition(threadID, formID) != -1;
	}
}