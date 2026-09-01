#include "ONudityDetector.h"

namespace SharpInternal::ONudityDetector
{
	bool RayTriIntersect(
		const RE::NiPoint3& start, const RE::NiPoint3& direction,
		const RE::NiPoint3& v0, const RE::NiPoint3& v1, const RE::NiPoint3& v2,
		float& outT
	)
	{
		constexpr float EPSILON = 1e-6f;

		auto edge1 = v1 - v0;

		auto edge2 = v2 - v0;

		auto h = direction.Cross(edge2);

		float a = edge1.Dot(h);

		if (a > -EPSILON && a < EPSILON)
			return false;

		auto f = 1.0f / a;

		auto s = start - v0;

		auto u = f * s.Dot(h);

		if (u < 0 || u > 1)
			return false;

		auto q = s.Cross(edge1);

		auto v = f * direction.Dot(q);

		if (v < 0 || u + v > 1)
			return false;

		auto t = f * edge2.Dot(q);

		if (t > EPSILON)
		{
			outT = t;

			return true;
		}
	
		return false;
	}

	bool IsSkin(RE::BSGeometry* a_geom)
	{
		if (!a_geom || a_geom->GetFlags().all(RE::NiAVObject::Flag::kHidden))
			return false;

		auto shaderProp = a_geom->lightingShaderProp_cast();

		if (shaderProp)
		{
			if (shaderProp->flags.all(RE::BSLightingShaderProperty::EShaderPropertyFlag::kSkinned))
				return true;
		}

		return false;
	}

	bool TryGetVertexPosition(const std::uint8_t* a_rawVertexData, std::uint32_t a_vertexSize, std::uint32_t a_posOffset, std::uint32_t a_vertexIndex, RE::NiPoint3& a_outPos)
	{
		if (!a_rawVertexData || a_vertexSize < sizeof(RE::NiPoint3))
			return false;

		if (a_posOffset > (a_vertexSize - sizeof(RE::NiPoint3)))
			return false;

		const auto byteOffset = static_cast<std::size_t>(a_vertexSize) * a_vertexIndex + a_posOffset;

		a_outPos = *reinterpret_cast<const RE::NiPoint3*>(a_rawVertexData + byteOffset);

		return true;
	}

	bool TryGetTriangleIndices(const std::uint16_t* a_rawIndexData, std::uint32_t a_triangleIndex, std::uint32_t& outIdx0, std::uint32_t& outIdx1, std::uint32_t& outIdx2)
	{
		if (!a_rawIndexData)
			return false;

		const auto baseIdx = static_cast<std::size_t>(a_triangleIndex) * 3;

		outIdx0 = a_rawIndexData[baseIdx];

		outIdx1 = a_rawIndexData[baseIdx + 1];

		outIdx2 = a_rawIndexData[baseIdx + 2];

		return true;
	}

	RayIntersection FirstRayHit(RE::Actor* a_actor, const RE::NiPoint3& start, const RE::NiPoint3& direction)
	{
		RayIntersection result;

		if (!a_actor)
			return result;

		auto root3D = a_actor->Get3D1(false);

		if (!root3D)
			return result;

		RE::NiPoint3 normalized = direction;

		normalized.Unitize();

		using Control = RE::BSVisit::BSVisitControl;

		RE::BSVisit::TraverseScenegraphGeometries(root3D,
			[&](RE::BSGeometry* a_geom) -> Control
			{
				if (!a_geom || a_geom->GetFlags().all(RE::NiAVObject::Flag::kHidden))
					return Control::kContinue;

				auto worldBound = a_geom->worldBound;

				auto oc = start - worldBound.center;

				auto b = oc.Dot(normalized);

				auto c = oc.Dot(oc) - (worldBound.radius * worldBound.radius);

				if ((c > 0 && b > 0) || b * b - c < 0)
					return Control::kContinue;

				auto triShape = a_geom->AsTriShape();

				auto rendererData = a_geom->GetGeometryRuntimeData().rendererData;

				if (!triShape || !rendererData)
					return Control::kContinue;

				auto vertexSize = rendererData->vertexDesc.GetSize();

				auto rawVertexData = rendererData->rawVertexData;

				auto rawIndexData = rendererData->rawIndexData;

				auto triangleCount = triShape->GetTrishapeRuntimeData().triangleCount;

				auto vertexCount = triShape->GetTrishapeRuntimeData().vertexCount;

				if (!rawVertexData || !rawIndexData || vertexSize == 0 || triangleCount == 0)
					return Control::kContinue;

				const auto offset = rendererData->vertexDesc.GetAttributeOffset(RE::BSGraphics::Vertex::Attribute::VA_POSITION);

				for (auto i = 0; i < triangleCount; ++i)
				{
					std::uint32_t idx0 = 0, idx1 = 0, idx2 = 0;

					if (!TryGetTriangleIndices(rawIndexData, i, idx0, idx1, idx2))
						continue;

					if (idx0 >= vertexCount || idx1 >= vertexCount || idx2 >= vertexCount)
						continue;

					RE::NiPoint3 v0, v1, v2;

					if (!TryGetVertexPosition(rawVertexData, vertexSize, offset, idx0, v0) ||
						!TryGetVertexPosition(rawVertexData, vertexSize, offset, idx1, v1) ||
						!TryGetVertexPosition(rawVertexData, vertexSize, offset, idx2, v2))
						continue;

					auto t = 0.0f;

					if (RayTriIntersect(start, direction, v0, v1, v2, t))
					{
						auto worldT = t * a_geom->world.scale;

						if (worldT < result.Distance)
						{
							result.Distance = worldT;

							result.HitPoint = start + (normalized * worldT);

							result.IsSkin = IsSkin(a_geom);
						}
					}
				}
			}
		);

		return result;
	}

	bool NippleNude(RE::Actor* a_actor)
	{
		if (!a_actor)
			return false;

		auto root3D = a_actor->Get3D1(false);

		if (!root3D)
			return false;

		auto intersection = FirstRayHit(a_actor, )
	}
}