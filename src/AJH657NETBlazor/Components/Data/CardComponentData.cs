using System;
using System.Threading.Tasks;
using AJH657NETBlazor.Data;
using AJH657NETBlazor.Util;
using AJH657NETBlazor.Util.Intefaces;
using Microsoft.AspNetCore.Components;

namespace AJH657NETBlazor.Components.Data
{
    public class CardComponentData : ComponentBase
    {
        [Inject]
        public ICardItemClient CardItemClient { get; set; }
        [Parameter]
        public string? CardHeader { get; set; }
        [Parameter]
        public int CardItemsPerRow { get; set; }
        [Parameter]
        public CardItem[] CardItems { get; set; }
        public int CardItemRowsCount => (int)Math.Round((decimal)CardItems.Length / CardItemsPerRow, MidpointRounding.AwayFromZero);

        protected override async Task OnInitializedAsync()
        {

            await base.OnInitializedAsync();
        }

    }
}
