using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace NewOdin_Blazor.Pages
{
    public partial class DashboardPartial : ComponentBase
    {
        [Inject]
        private ViewModels.GanttViewModel ViewModel { get; set; } = null!;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await ViewModel.InitializeGanttAsync();
            }
        }

        public async Task SaveGanttData()
        {
            await ViewModel.SaveGanttDataAsync();
        }
    }
}
