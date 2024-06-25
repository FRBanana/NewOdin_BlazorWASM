// Services/GanttDataService.cs
using NewOdin_Blazor.Models;
using System.Threading.Tasks;

namespace NewOdin_Blazor.Services
{
    public class GanttDataService
    {
        public string LoadGanttDataFromApi()
        {
            // Mock data representing the response from the API
            string apiURL = "https://192.168.211.48:9095/api/order/get-all";

            return apiURL;
        }
    }
}
