using Azure.Storage.Blobs;

namespace AJH657NETBlazor.Util.Intefaces
{
    public interface IBlobStorageServiceClientSolver
    {
        BlobServiceClient GetBlobServiceClient();
    }
}
