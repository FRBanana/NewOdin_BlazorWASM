using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NewOdin_Blazor.Models;

namespace NewOdin_Blazor.Components
{
	public partial class Gantt
	{
		[Inject]
		public required IJSRuntime JS { get; set; }

		private IJSObjectReference? ganttModule;
		private ElementReference? ganttContainer;

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
				ganttModule = await JS.InvokeAsync<IJSObjectReference>("import", "./js/component/gantt.js");
				InitGantt();
			}
		}

		public void InitGantt()
		{
			ganttModule?.InvokeVoidAsync("initGantt", ganttContainer);
		}

		public void LoadGanttData(string dataUrl)
		{
			ganttModule?.InvokeVoidAsync("loadGanttFromUrl", dataUrl);
		}

		public void LoadGanttData(DHXGanttData ganttData)
		{
			ganttModule?.InvokeVoidAsync("loadGanttFromJson", ganttData);
		}
	}
}
