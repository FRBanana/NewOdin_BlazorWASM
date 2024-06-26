using NewOdin_Blazor.Models;
using NewOdin_Blazor.Services;

namespace NewOdin_Blazor.ViewModels
{
    public class GanttViewModel
    {
        private readonly GanttService _ganttService;

        public GanttViewModel(GanttService ganttService)
        {
            _ganttService = ganttService;
        }

        public async Task<GanttDataModel> GetGanttDataAsync()
        {
            return await _ganttService.GetGanttDataAsync();
        }
    }
}
