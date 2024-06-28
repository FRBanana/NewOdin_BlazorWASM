using NewOdin_Blazor.Models;

public class GanttSaveResult
{
    public GanttTaskModel? AddedTasksResult { get; set; }
    public GanttTaskModel? UpdatedTasksResult { get; set; }
    public GanttTaskModel? DeletedTasksResult { get; set; }
}
