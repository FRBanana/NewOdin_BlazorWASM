// ViewModels/GanttViewModel.cs
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace NewOdin_Blazor.ViewModels
{
    public class GanttViewModel
    {
        private readonly IJSRuntime _jsRuntime;

        public GanttViewModel(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task InitializeGanttAsync()
        {
            await _jsRuntime.InvokeVoidAsync("initGantt");
        }
    }
}
