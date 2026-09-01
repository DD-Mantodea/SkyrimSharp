using SkyrimSharpLoader.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyrimSharpLoader.Interop.REL
{
    public unsafe readonly struct VariantID(ulong seID, ulong aeID, ulong vrOffset)
    {
        private readonly ulong _seID = seID;

        private readonly ulong _aeID = aeID;

        private readonly ulong _vrOffset = vrOffset;

        public ulong Address()
        {
            var offset = Offset();

            return offset == 0 ? 0 : AddressLib.GetAddr(_aeID);
        }

        public ulong Offset()
        {
            return _aeID == 0 ? 0 : AddressLib.ID2Offset(_aeID);
        }

        public void** GetVtable()
        {
            return (void**)Address();
        }
    }
}
