using System;
using System.IO;
using System.Threading.Tasks;
using AJH657NETBlazor.Util.Intefaces;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace AJH657NETBlazor.Util
{
    public class BlobCache : IBlobCache
    {

        private readonly IMemoryCache _memoryCache;
        private readonly IBlobStorageClient _blobClient;

        public BlobCache(IMemoryCache memoryCache, IBlobStorageClient blobClient)
        {
            _memoryCache = memoryCache;
            _blobClient = blobClient;
        }

        public async Task<T> GetAsync<T>(string ID, string Container, CacheItemPriority itemPriority = CacheItemPriority.Normal)
        {
            if (_memoryCache.TryGetValue(Container+ID, out var data))
            {
                return (T)data;
            }
            else
            {
                var newDataBlobItem = await _blobClient.GetBlobItemAsync(ID, Container);
                var streamReader = new StreamReader(newDataBlobItem);

                var newData = JsonConvert.DeserializeObject<T>(await streamReader.ReadToEndAsync());

                var cacheOptions = new MemoryCacheEntryOptions()
                {
                    SlidingExpiration = TimeSpan.FromMinutes(5),
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
                    Priority = itemPriority
                };
                _memoryCache.Set(Container+ID, newData,cacheOptions);

                return newData;
            }
        }

        public async Task<string[]> GetContainerItemsAsync(string Container, CacheItemPriority itemPriority = CacheItemPriority.Normal)
        {
            if (_memoryCache.TryGetValue(Container, out var data))
            {
                return (string[])data;
            }
            else
            {
                return await _blobClient.GetBlobItemsInContainerAsync(Container);
            }
        }
    }
}
