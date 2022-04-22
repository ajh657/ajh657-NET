using AJH657NETBlazor.Util.Intefaces;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace AJH657NETBlazor.Util
{
    public class BlobStorageServiceClientSolver : IBlobStorageServiceClientSolver
    {

        private BlobServiceClient _blobServiceClient;
        private IConfiguration _configuration;

        public BlobStorageServiceClientSolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public BlobServiceClient GetBlobServiceClient()
        {
            if (_blobServiceClient != null)
                return _blobServiceClient;

            var newServiceClient = CreateNewClient();
            _blobServiceClient = newServiceClient;
            return newServiceClient;
        }

        private BlobServiceClient CreateNewClient()
        {
            return new BlobServiceClient(_configuration.GetConnectionString("BlobStorage"));
        }
    }
}
