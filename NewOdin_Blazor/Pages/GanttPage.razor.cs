using Microsoft.AspNetCore.Components;
using NewOdin_Blazor.Components;
using NewOdin_Blazor.Models;
using NewOdin_Blazor.ViewModels;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace NewOdin_Blazor.Pages
{
    public partial class GanttPage : ComponentBase
    {
        [Inject]
        protected GanttViewModel? GanttViewModel { get; set; }

        private GanttComponent? ganttComponent;

        private async Task DisplayGantt()
        {
            if (ganttComponent is not null && GanttViewModel is not null)
            {
                var ganttData = await GanttViewModel.GetGanttDataAsync();
                await ganttComponent.DisplayDataAsync(ganttData);
            }
        }

        private async Task SaveGantt()
        {
            var addedTasks = await ganttComponent.AddDataAsync();
            var updatedTasks = await ganttComponent.UpdateDataAsync();
            var deletedTasks = await ganttComponent.DeleteDataAsync();

            await GanttViewModel.SaveGanttDataAsync(addedTasks, updatedTasks, deletedTasks);
        }

        private async Task ShowTask()
        {
            var ganttData = await ganttComponent.ShowTaskDataAsync();

            Console.WriteLine(ganttData);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}
