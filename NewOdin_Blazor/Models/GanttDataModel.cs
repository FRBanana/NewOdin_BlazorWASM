// Models/GanttDataModel.cs
using System;
using System.Collections.Generic;

namespace NewOdin_Blazor.Models
{
    public class GanttTask
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public string? StartDate { get; set; }
        public int Duration { get; set; }
        public double Progress { get; set; }
        public int? Parent { get; set; }
    }

    public class GanttLink
    {
        public int Id { get; set; }
        public int Source { get; set; }
        public int Target { get; set; }
        public string? Type { get; set; }
    }

    public class GanttData
    {
        public List<GanttTask>? Data { get; set; }
        public List<GanttLink>? Links { get; set; }
    }
}
