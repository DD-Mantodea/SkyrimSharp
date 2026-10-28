using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyrimSharpLoader.Extensions
{
    public static class ListExt
    {
        public static bool OutOfRange<T>(this List<T> list, int index)
        {
            return index >= list.Count || index < 0;
        }

        public static bool TryAdd<T>(this List<T> list, T item)
        {
            if (list.Contains(item))
                return false;

            list.Add(item);

            return true;
        }
    }
}
