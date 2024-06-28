// Define an array to store updated tasks
let addedTasks = [];
let updatedTasks = [];
let deletedTasks = [];

export function initGantt(ganttContainer) {
    gantt.config.date_format = "%Y-%m-%d %H:%i";

    gantt.init(ganttContainer);
    console.log("Gantt initialized.");

    // Event listener for task updates
    gantt.attachEvent("onBeforeTaskAdd", function (taskId, task) {
        task.id = getLastTaskId() + 1;
        gantt.changeTaskId(taskId, getLastTaskId() + 1);
        console.log("Task ID:", task.id);

        var pushTask = {
            id: task.id,
            text: task.text,
            start_date: formatDate(task.start_date),
            end_date: formatDate(task.end_date),
        }

        addedTasks.push(pushTask); // Add task to the array
    });

    gantt.attachEvent("onAfterTaskUpdate", function (id, task) {
        var pushTask = {
            id: task.id,
            text: task.text,
            start_date: formatDate(task.start_date),
            end_date: formatDate(task.end_date),
        };

        updatedTasks.push(pushTask); // Add updated task to the array
    });

    gantt.attachEvent("onBeforeTaskDelete", function (id, task) {
        deletedTasks.push(id); // Add updated task to the array
        return true;
    });
}

export function loadGanttData(jsonData) {
    gantt.clearAll();
    console.log("Gantt contents cleared.");

    gantt.parse(jsonData);
    console.log("Gantt data loaded.");
}

// Function to get updated tasks
export function getAddedTasks() {
    return addedTasks;
}

export function getUpdatedTasks() {
    return updatedTasks;
}

export function getDeletedTasks() {
    return deletedTasks;
}

// Function to clear updated tasks array
export function clearUpdatedTasks() {
    addedTasks = [];
}

function getLastTaskId() {
    var tasks = gantt.getTaskByTime(); // Get all tasks ordered by time
    if (tasks.length > 0) {
        const lastTaskId = tasks[tasks.length - 2].id; // Get the last task ID
        return lastTaskId;
    }
    return 0; // Return 0 if there are no tasks
}

function formatDate(dateString) {
    const date = new Date(dateString);
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0');
    const hours = String(date.getHours()).padStart(2, '0');
    const minutes = String(date.getMinutes()).padStart(2, '0');
    const seconds = String(date.getSeconds()).padStart(2, '0');

    return `${year}-${month}-${day} ${hours}:${minutes}:${seconds}`;
}