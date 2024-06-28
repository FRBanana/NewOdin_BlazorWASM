namespace NewOdin_Blazor.Services.Base
{
    public class ApiConfig
    {
        public string? BaseUrl { get; set; }
        public string? GanttDataEndpoint { get; set; }
        public string? InsertGanttDataEndpoint { get; set; }
        public string? UpdateGanttDataEndpoint { get; set; }
        public string? DeleteGanttDataEndpoint { get; set; }
    }
}
