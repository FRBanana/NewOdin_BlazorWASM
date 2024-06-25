// ViewModels/GanttViewModel.cs
using Microsoft.JSInterop;
using NewOdin_Blazor.Models;
using NewOdin_Blazor.Services;
using System.Threading.Tasks;

namespace NewOdin_Blazor.ViewModels
{
    public class GanttViewModel
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly GanttDataService _ganttDataService;

        public GanttViewModel(IJSRuntime jsRuntime, GanttDataService ganttDataService)
        {
            _jsRuntime = jsRuntime;
            _ganttDataService = ganttDataService;
        }

        public async Task InitializeGanttAsync()
        {
            var ganttData = _ganttDataService.LoadGanttDataFromApi();

            await _jsRuntime.InvokeVoidAsync("initGantt", ganttData);
        }

        public async Task SaveGanttDataAsync()
        {
            await _jsRuntime.InvokeVoidAsync("saveGanttData");
        }
    }
}
