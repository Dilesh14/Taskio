using System.IO;
using System.Threading.Tasks;

namespace Taskio.Interface
{
    public interface IPhotoPicker
    {
        Task<Stream> GetImageStreamAsync();
    }
}