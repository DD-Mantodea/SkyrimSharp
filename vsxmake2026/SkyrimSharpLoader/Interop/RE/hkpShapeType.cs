namespace SkyrimSharpLoader.Interop.RE
{
    public enum hkpShapeType
    {
        kInvalid = 0,

        kSphere,
        kFirstType = 1,
        kCylinder,
        kTriangle,
        kBox,
        kCapsule,
        kConvexVertices,
        kCollection,
        kBVTree,
        kList,
        kMOPP,
        kConvexTranslate,
        kConvexTransform,
        kSampledHeightField,
        kExtendedMesh,
        kTransform,
        kCompressedMesh,
        kCompound,

        kTotalSPU = kCompound + 1,

        kConvex,
        kMOPPEmbedded,
        kConvexPiece,
        kMultiSphere,
        kConvexList,
        kTriangleCollection,
        kMultiRay,
        kHeightField,
        kSphereRep,
        kBV,
        kPlane,
        kPhantomCallback,
        kUser0,
        kUser1,
        kUser2,

        kTotal,

        kAll = -1
    }
}
