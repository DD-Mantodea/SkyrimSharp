using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SkyrimSharpLoader.Utils
{
    public class RegistryUtils
    {
        public static Type[] Parameters2Types(ParameterInfo[] paras)
        {
            Type[] types = new Type[paras.Length];
            var list = paras.ToList();
            foreach (var p in list)
            {
                types[list.IndexOf(p)] = p.ParameterType;
            }
            return types;
        }
    }
}
