using SkyrimSharpLoader.Interop.RE;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimSharpLoader.Internal
{
    public static unsafe class Form
    {
        internal static delegate* unmanaged<uint, TESForm.Internal*> _lookupByID;

        internal static TESForm.Internal* LookupByID(uint formID)
            => _lookupByID == null ? null : _lookupByID(formID);

        internal static delegate* unmanaged<byte*, TESForm.Internal*> _lookupByEditorID;

        internal static TESForm.Internal* LookupByEditorID(string editorID)
        {
            if (_lookupByEditorID == null || editorID == null)
                return null;

            var bytes = Encoding.UTF8.GetBytes(editorID + '\0');

            fixed (byte* p = bytes)
                return _lookupByEditorID(p);
        }

        internal static delegate* unmanaged<uint, TESFile.Internal*> _lookupPluginByID;

        internal static TESFile.Internal* LookupPluginByID(uint formID)
            => _lookupPluginByID == null ? null : _lookupPluginByID(formID);
    }
}
