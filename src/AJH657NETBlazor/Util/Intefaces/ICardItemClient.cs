using System.Threading.Tasks;
using AJH657NETBlazor.Data;

namespace AJH657NETBlazor.Util.Intefaces
{
    public interface ICardItemClient
    {
        Task<CardItem[]> GetCardItemsAsync();
    }
}
