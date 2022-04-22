using System.Collections.Generic;
using System.Threading.Tasks;
using AJH657NETBlazor.Data;
using AJH657NETBlazor.Util.Intefaces;
using Microsoft.Extensions.Configuration;

namespace AJH657NETBlazor.Util
{
    public class CardItemClient : ICardItemClient
    {

        private IBlobCache _cache;
        private readonly IConfiguration _configuration;

        public CardItemClient(IBlobCache cache, IConfiguration configuration)
        {
            _cache = cache;
            _configuration = configuration;
        }

        public async Task<CardItem[]> GetCardItemsAsync()
        {
            var cardItems = new List<CardItem>();
            var cardItemContainer = _configuration["BlobStorage:CardItems"];

            var cardItemsInContainer = await _cache.GetContainerItemsAsync(cardItemContainer);
            
            foreach (var item in cardItemsInContainer)
            {
                cardItems.Add(await _cache.GetAsync<CardItem>(item, cardItemContainer));
            }

            return cardItems.ToArray();
        }
    }
}
