
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
    }
}
