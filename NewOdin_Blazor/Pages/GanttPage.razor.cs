using Microsoft.AspNetCore.Components;
using NewOdin_Blazor.Components;
using NewOdin_Blazor.ViewModels;
using System.Threading.Tasks;

namespace NewOdin_Blazor.Pages
{
    public partial class GanttPage : ComponentBase
    {
        [Inject]
        protected GanttViewModel GanttViewModel { get; set; }

        private GanttComponent ganttComponent;

        private async Task DisplayGantt()
        {
            var ganttData = await GanttViewModel.GetGanttDataAsync();
            await ganttComponent.DisplayDataAsync(ganttData);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}
