using System.Net.Http.Json;

namespace NewOdin_Blazor.Services.Base
{
	public abstract class BaseApiService
	{
		private readonly HttpClient _httpClient;

		public BaseApiService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		// Generic method to GET data from an API endpoint
		protected async Task<T> GetAsync<T>(string uri)
		{
			var response = await _httpClient.GetAsync(uri);
			response.EnsureSuccessStatusCode();

			var result = await response.Content.ReadFromJsonAsync<T>();
			if (result == null)
			{
				throw new ApplicationException($"The response from {uri} was null.");
			}

			return result;
		}

		// Generic method to POST data to an API endpoint
		protected async Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest data)
		{
			var response = await _httpClient.PostAsJsonAsync(uri, data);
			response.EnsureSuccessStatusCode();

			var result = await response.Content.ReadFromJsonAsync<TResponse>();
			if (result == null)
			{
				throw new ApplicationException($"The response from {uri} was null.");
			}

			return result;
		}

		// Generic method to PUT data to an API endpoint
		protected async Task<TResponse> PutAsync<TRequest, TResponse>(string uri, TRequest data)
		{
			var response = await _httpClient.PutAsJsonAsync(uri, data);
			response.EnsureSuccessStatusCode();

			var result = await response.Content.ReadFromJsonAsync<TResponse>();
			if (result == null)
			{
				throw new ApplicationException($"The response from {uri} was null.");
			}

			return result;
		}

		// Generic method to PATCH data to an API endpoint
		protected async Task<TResponse> PatchAsync<TRequest, TResponse>(string uri, TRequest data)
		{
			var response = await _httpClient.PatchAsJsonAsync(uri, data);
			response.EnsureSuccessStatusCode();

			var result = await response.Content.ReadFromJsonAsync<TResponse>();
			if (result == null)
			{
				throw new ApplicationException($"The response from {uri} was null.");
			}

			return result;
		}

		// Generic method to DELETE data from an API endpoint
		protected async Task DeleteAsync(string uri)
		{
			var response = await _httpClient.DeleteAsync(uri);
			response.EnsureSuccessStatusCode();
		}
	}
}
