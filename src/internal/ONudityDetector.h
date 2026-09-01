#pragma once

#include<float.h>

namespace SharpInternal::ONudityDetector
{
	struct RayIntersection
	{
		bool Intersect = false;

		bool IsSkin = false;

		RE::NiPoint3 HitPoint;

		float Distance = FLT_MAX;
	};

	bool NippleNude(RE::Actor* a_actor);
}