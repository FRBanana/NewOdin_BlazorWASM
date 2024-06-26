export function initGantt(ganttContainer) {
    gantt.config.date_format = "%Y-%m-%d %H:%i";

    gantt.init(ganttContainer);
    console.log("Gantt initialized.")
}

export function loadGanttData(jsonData) {
    gantt.clearAll();
    console.log("Gantt contents cleared.")

    gantt.parse(jsonData);
    console.log("Gantt data loaded.")
}