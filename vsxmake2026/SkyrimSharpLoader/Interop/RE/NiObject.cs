namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct NiObject : INiObject
    {
        public struct Internal
        {
            internal NiRefObject.Internal Base;

            //TODO
        }
    }

    public interface INiObject : INiRefObject;
}
