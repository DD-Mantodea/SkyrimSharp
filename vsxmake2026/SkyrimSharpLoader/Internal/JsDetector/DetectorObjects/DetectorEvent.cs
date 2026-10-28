using System.Reflection;

namespace SkyrimSharpLoader.Internal.JsDetector.DetectorObjects
{
    public class DetectorEvent(EventInfo @event) : DetectorObject
    {
        public EventInfo Event = @event;

        public override string Serialize()
        {
            return "";
        }
    }
}
