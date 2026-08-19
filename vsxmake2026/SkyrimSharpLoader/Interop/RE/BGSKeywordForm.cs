using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BGSKeywordForm
    {
        public struct Internal
        {
            internal BaseFormComponent.Internal Base;

            internal BGSKeyword.Internal** Keywords;

            internal uint NumKeywords;

            internal uint pad14;
        }
    }
}
