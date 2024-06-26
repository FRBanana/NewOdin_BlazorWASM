using System.Text.Json.Serialization;

namespace NewOdin_Blazor.Models
{
	public class GanttDataModel
	{
		[JsonPropertyName("tasks")]
		public List<GanttTaskModel>? Tasks { get; set; }
	}
}
