using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NewOdin_Blazor.Models;
using System.Threading.Tasks;

namespace NewOdin_Blazor.Components
{
    public partial class GanttComponent : ComponentBase
    {
        [Inject]
        protected IJSRuntime JS { get; set; }

        private ElementReference ganttContainer;
        private IJSObjectReference ganttModule;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                ganttModule = await JS.InvokeAsync<IJSObjectReference>("import", "./js/component/gantt.js");
                await InitGanttAsync();
            }
        }

        public async Task InitGanttAsync()
        {
            if (ganttModule is not null)
            {
                await ganttModule.InvokeVoidAsync("initGantt", ganttContainer);
            }
        }

        public async Task DisplayDataAsync(GanttDataModel ganttData)
        {
            if (ganttModule is not null)
            {
                await ganttModule.InvokeVoidAsync("loadGanttData", ganttData);
            }
        }
    }
}
