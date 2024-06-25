using NewOdin_Blazor.Models;

namespace NewOdin_Blazor.Services.Interfaces
{
	public interface IGanttService
	{
		string ConstructGanttQueryUrl();

		Task<DHXGanttData> GetGanttData();
	}
}
