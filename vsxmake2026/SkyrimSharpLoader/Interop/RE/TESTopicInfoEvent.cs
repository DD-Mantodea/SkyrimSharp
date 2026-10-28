using SkyrimSharpLoader.Internal;
using SkyrimSharpLoader.Interop.Interfaces;
using SkyrimSharpLoader.Interop.RE.REFREventCallbacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyrimSharpLoader.Interop.RE
{
    public struct TESTopicInfoEvent
    {
        public enum TopicInfoEventType
        {
            kTopicBegin,
            kTopicEnd
        }

        public BSTSmartPointer<IEventCallback> Callback;

        public NiPointer<TESObjectREFR.Internal> SpeakerRef;

        public uint TopicInfoFormID;

        public TopicInfoEventType Type;

        public ushort Stage;

        public readonly TESTopicInfo GetInfo()
        {
            var info = TESForm.LookupByID(TopicInfoFormID);

            if (info.Native == 0)
                return default;

            return info.As<TESTopicInfo>();
        }
    }
}
