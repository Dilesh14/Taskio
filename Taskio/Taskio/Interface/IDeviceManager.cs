using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Taskio.Interface
{
    public interface IDeviceManager
    {
       Task<IDictionary<string, string>> BuildImageMedia();
    }
}
