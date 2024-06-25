using Microsoft.AspNetCore.Components;
using NewOdin_Blazor.Components;
using NewOdin_Blazor.Services.Interfaces;

namespace NewOdin_Blazor.Pages
{
	public partial class Home
	{
		[Inject]
		public required IGanttService GanttService { get; set; }

		private Gantt? ganttComponent;

		private void DisplayGanttFromUrl()
		{
			var ganttUrl = GanttService.ConstructGanttQueryUrl();

			if (ganttComponent is not null)
			{
				ganttComponent.LoadGanttData(ganttUrl);
			}
		}

		private async void DisplayGanttFromData()
		{
			var ganttData = await GanttService.GetGanttData();

			if (ganttComponent is not null)
			{
				ganttComponent.LoadGanttData(ganttData);
			}
		}
	}
}