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

        public async Task<GanttSaveResult> SaveGanttDataAsync(List<GanttTaskModel> addedTasks, List<GanttTaskModel> updatedTasks, List<int> deletedTasks)
        {
            return await _ganttService.SaveGanttDataAsync(addedTasks, updatedTasks, deletedTasks);
        }
    }
}
