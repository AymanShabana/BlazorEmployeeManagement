using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Razor.CustomComponents
{
    public class ConfirmBase : ComponentBase
    {
        protected bool Display { get; set; }
        [Parameter]
        public EventCallback<bool> ChoiceSelected { get; set; }
        [Parameter]
        public string Title { get; set; } = "Delete Confirmation";
        [Parameter]
        public string Body { get; set; } = "Are you sure?";
        [Parameter]
        public string YesOption { get; set; } = "Yes";
        [Parameter]
        public string NoOption { get; set; } = "Cancel";
        public void Show()
        {
            Display = true;
            StateHasChanged();
        }
        protected async Task OnChoiceSelected(bool value)
        {
            Display = false;
            await ChoiceSelected.InvokeAsync(value);
        }
    }
}
