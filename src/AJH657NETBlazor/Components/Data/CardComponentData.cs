using System;
using AJH657NETBlazor.Data;
using AJH657NETBlazor.Util;
using Microsoft.AspNetCore.Components;

namespace AJH657NETBlazor.Components.Data
{
    public class CardComponentData : ComponentBase
    {
        [Parameter]
        public string? CardHeader { get; set; }
        [Parameter]
        public int CardItemsPerRow { get; set; }
        [Parameter]
        public CardItem[] CardItems { get; set; }

        public CardItem[,] CardItemRows;

        protected override void OnParametersSet()
        {
            CardItemRows = CardItems.Make2DArray((int)Math.Round((double)(CardItems.Length / CardItemsPerRow), MidpointRounding.AwayFromZero), CardItemsPerRow);
            base.OnParametersSet();
        }

    }
}
