using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BGSKeyword : IBGSKeyword
    {
        public enum RecordFlags
        {
            kDeleted = 1 << 5,
            kIgnored = 1 << 12
        }

        public struct Internal
        {
            internal TESForm.Internal Base;

            internal BSFixedString FormEditorID;
        }
    }

    public interface IBGSKeyword : ITESForm;
}
