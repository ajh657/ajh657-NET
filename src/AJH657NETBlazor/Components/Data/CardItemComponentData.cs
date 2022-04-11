using System;
using Microsoft.AspNetCore.Components;

namespace AJH657NETBlazor.Components.Data
{
    public class CardItemComponentData : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public string TextColor { get; set; }
        [Parameter]
        public string BackgroundColor { get; set; }
        [Parameter]
        public int PaddingSize { get; set; } = 8;
        [Parameter]
        public string ShadowSize { get; set; } = "lg";
        [Parameter]
        public string RoundedSize { get; set; } = "lg";
        [Parameter]
        public string? href { get; set; }
        [Parameter]
        public string? IconClass { get; set; }

    }
}
