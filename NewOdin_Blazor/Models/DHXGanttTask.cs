using System.Text.Json.Serialization;

namespace NewOdin_Blazor.Models
{
	public class DHXGanttTask
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("text")]
		public string? Text { get; set; }

		[JsonPropertyName("start_date")]
		public string? StartDate { get; set; }

		[JsonPropertyName("end_date")]
		public string? EndDate { get; set; }
	}
}
