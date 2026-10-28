using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.REX.W32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FILETIME
    {
        internal uint Lo;
        internal uint Hi;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct WIN32_FIND_DATAA
    {
        internal uint FileAttributes;
        internal FILETIME CreationTime;
        internal FILETIME LastAccessTime;
        internal FILETIME LastWriteTime;
        internal uint FileSizeHi;
        internal uint FileSizeLo;
        internal uint Reserved0;
        internal uint Reserved1;
        internal fixed byte FileName[260];
        internal fixed byte FileNameAlt[14];
    }
}
