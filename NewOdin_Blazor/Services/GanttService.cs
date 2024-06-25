
using NewOdin_Blazor.Models;
using NewOdin_Blazor.Services.API;
using NewOdin_Blazor.Services.Interfaces;

namespace NewOdin_Blazor.Services
{
	public class GanttService : BaseApiService, IGanttService
	{
		private readonly ApiConfig _apiConfig;

		public GanttService(HttpClient httpClient, ApiConfig apiConfig) : base(httpClient)
		{
			_apiConfig = apiConfig;
		}

		public string ConstructGanttQueryUrl()
		{
			// Can append the search query here like the start and end date, resource type, etc.
			return $"{_apiConfig.BaseUrl}{_apiConfig.GanttDataEndpoint}";
		}

		public async Task<DHXGanttData> GetGanttData()
		{
			var url = $"{_apiConfig.BaseUrl}{_apiConfig.GanttDataEndpoint}";
			return await GetAsync<DHXGanttData>(url);
		}
	}
}
