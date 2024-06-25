const ganttContainerId = "gantt-container"

export function initGantt() {
    gantt.init(ganttContainerId);
    console.log("Gantt initialized.")
}

export function loadGanttFromUrl(dataUrl) {
    gantt.clearAll();
    console.log("Gantt contents cleared.")

    gantt.load(dataUrl);
}

export function loadGanttFromJson(jsonData) {
    gantt.clearAll();
    console.log("Gantt contents cleared.")

    gantt.parse(jsonData);
}