using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AJH657NETBlazor.Util.Intefaces;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;

namespace AJH657NETBlazor.Util
{
    public class BlobStorageClient : IBlobStorageClient
    {
        private readonly BlobServiceClient _blobStorageClient;

        public BlobStorageClient(IBlobStorageServiceClientSolver blobStorageServiceClientSolver)
        {
            _blobStorageClient = blobStorageServiceClientSolver.GetBlobServiceClient();
        }

        public async Task<Stream> GetBlobItemAsync(string ID,string ContainerID)
        {
            var containerClient = _blobStorageClient.GetBlobContainerClient(ContainerID);
            var blobClient = containerClient.GetBlobClient(ID);
            return await blobClient.OpenReadAsync();
        }

        public async Task<string[]> GetBlobItemsInContainerAsync(string ContainerID)
        {
            var containerClient = _blobStorageClient.GetBlobContainerClient(ContainerID);
            var blobItems = new List<BlobItem>();

            await foreach (var item in containerClient.GetBlobsAsync())
            {
                if (!item.Deleted)
                {
                    blobItems.Add(item);
                }
            }

            return blobItems.Select(_ => _.Name).ToArray();
        }
    }
}
