using SkyrimSharpLoader.Interop.RE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyrimSharpLoader.Interop.Interfaces
{
    public interface IHaveVtable
    {
        Dictionary<string, Vtable> Vtables { get; }
    }
}
