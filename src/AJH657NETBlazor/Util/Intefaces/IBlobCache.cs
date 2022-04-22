using System.Threading.Tasks;
using AJH657NETBlazor.Data;
using Microsoft.Extensions.Caching.Memory;

namespace AJH657NETBlazor.Util.Intefaces
{
    public interface IBlobCache
    {
        Task<T> GetAsync<T>(string ID,string Container, CacheItemPriority itemPriority = CacheItemPriority.Normal);
        Task<string[]> GetContainerItemsAsync(string Container, CacheItemPriority itemPriority = CacheItemPriority.Normal);
    }
}
