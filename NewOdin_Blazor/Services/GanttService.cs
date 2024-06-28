
using NewOdin_Blazor.Models;
using NewOdin_Blazor.Services.Base;

namespace NewOdin_Blazor.Services
{
    public class GanttService : BaseApiService
    {
        private readonly ApiConfig _apiConfig;

        public GanttService(HttpClient httpClient, ApiConfig apiConfig) : base(httpClient)
        {
            _apiConfig = apiConfig;
        }

        public async Task<GanttDataModel> GetGanttDataAsync()
        {
            var url = $"{_apiConfig.BaseUrl}{_apiConfig.GanttDataEndpoint}";
            return await GetAsync<GanttDataModel>(url);
        }

        public async Task<GanttSaveResult> SaveGanttDataAsync(List<GanttTaskModel> addedTasks, List<GanttTaskModel> updatedTasks, List<int> deletedTasks)
        {
            GanttSaveResult result = new GanttSaveResult();

            // Add Tasks
            var urlAdd = $"{_apiConfig.BaseUrl}{_apiConfig.InsertGanttDataEndpoint}";
            if (addedTasks != null && addedTasks.Any())
            {
                result.AddedTasksResult = await PostAsync<List<GanttTaskModel>, GanttTaskModel>(urlAdd, addedTasks);
            }

            // Update Tasks
            var urlUpdate = $"{_apiConfig.BaseUrl}{_apiConfig.UpdateGanttDataEndpoint}";
            if (updatedTasks != null && updatedTasks.Any())
            {
                result.UpdatedTasksResult = await PatchAsync<List<GanttTaskModel>, GanttTaskModel>(urlUpdate, updatedTasks);
            }

            // Delete Tasks
            var urlDelete = $"{_apiConfig.BaseUrl}{_apiConfig.DeleteGanttDataEndpoint}";
            if (urlDelete != null && urlDelete.Any())
            {
                result.DeletedTasksResult = await DeleteAsync<List<int>, GanttTaskModel>(urlDelete, deletedTasks);
            }

            return result;
        }

    }
}
