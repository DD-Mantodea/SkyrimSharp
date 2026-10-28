#pragma once

#include "internal/Event.h"

namespace SharpInternal::JsFragment
{
	inline constexpr const char* kTopicInfoEventname = "TopicInfoEvent";

	void AddListener();
}