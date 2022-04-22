using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;

namespace AJH657NETBlazor.Util.Intefaces
{
    public interface IBlobStorageClient
    {
        Task<string[]> GetBlobItemsInContainerAsync(string ContainerID);
        Task<Stream> GetBlobItemAsync(string ID, string ContainerID);
    }
}
