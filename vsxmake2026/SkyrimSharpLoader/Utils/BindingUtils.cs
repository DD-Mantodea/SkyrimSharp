using Jint.Runtime.Interop;
using SkyrimSharpLoader.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyrimSharpLoader.Utils
{
    public class BindingUtils
    {
        public static List<(string, object)> Values = [];

        public static void BindInstance(string name, object instance)
        {
            JsFragment.Engine.SetValue(name, instance);
            Values.Add((name, instance));
        }

        public static void BindStaticOrEnumOrConst(string name, Type type)
        {
            JsFragment.Engine.SetValue(name, TypeReference.CreateTypeReference(JsFragment.Engine, type));
            Values.Add((name, type));
        }

        public static void BindInnerMethod(string name, Delegate @delegate)
        {
            JsFragment.Engine.SetValue(name, @delegate);
            Values.Add((name, @delegate));
        }

        public static void Clear()
        {
            Values.Clear();
        }
    }
}
