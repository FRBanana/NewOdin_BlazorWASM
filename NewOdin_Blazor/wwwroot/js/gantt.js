import * as templates from "./templates.js";

export function initGantt() {
    console.log("hello")

	initGanttLayout(gantt);
	initGanttLightBox(gantt);

    gantt.init("gantt_here");
	loadData();

	console.log("LICENSE: " + gantt.license);
}

function loadData() {
	var apiURL = "https://192.168.211.48:9094/swagger/index.html";

	gantt.load(apiURL);
}

function initGanttLayout(gantt) {
	gantt.config.columns = templates.defaultColumn(gantt);
	gantt.config.resource_property = "nice";
	gantt.config.resource_attribute = "nice-id";

	const custom_layout = {
		css: "gantt_container",
		rows: [
			{
				// Main Chart Config
				cols: [
					{ view: "grid", group: "grids", scrollY: "scrollVer" },
					{ resizer: true, width: 1 },
					{ view: "timeline", scrollX: "scrollHor", scrollY: "scrollVer" },
					{ view: "scrollbar", id: "scrollVer", group: "vertical" }
				],
				gravity: 1
			},
			{ resizer: true, width: 1 },
			// Resource Load Diagram
			{
				config: templates.resourceLoadChart(gantt),
				cols: [
					{ view: "resourceGrid", group: "grids", width: 435, scrollY: "resourceVScroll" },
					{ resizer: true, width: 1 },
					{ view: "resourceTimeline", scrollX: "scrollHor", scrollY: "resourceVScroll" },
					{ view: "scrollbar", id: "resourceVScroll", group: "vertical" }
				],
				gravity: 1
			},
			{ resizer: true, width: 1 },
			// Resource Capacity Diagram
			{
				config: templates.resourceCapacityChart(gantt),
				cols: [
					{ view: "resourceGrid", group: "grids", width: 435, scrollY: "resourceVScroll" },
					{ resizer: true, width: 1 },
					{ view: "resourceHistogram", scrollX: "scrollHor", scrollY: "resourceVScroll" },
					{ view: "scrollbar", id: "resourceVScroll", group: "vertical" }
				],
				gravity: 1
			},
			{ view: "scrollbar", id: "scrollHor" }
		]
	};

	// Layout
	gantt.config.layout = custom_layout;
}

// Gantt Lightbox
function initGanttLightBox(gantt) {
	gantt.locale.labels.section_item_name = "Item Name";
	gantt.locale.labels.section_memo = "Memo";
	gantt.locale.labels.section_period = "Time Period";
	gantt.locale.labels.section_custom_progress = "Progress";
	gantt.locale.labels.section_baseline = "Planned";
	gantt.locale.labels.section_resources = "Resource Name";

	gantt.locale.labels.baseline_enable_button = 'Set';
	gantt.locale.labels.baseline_disable_button = 'Remove';

	gantt.config.lightbox.sections = [
		{ name: "item_name", height: 30, map_to: "text", type: "textarea", focus: true },
		{ name: "memo", height: 72, map_to: "memo", type: "textarea", focus: true },
		{
			name: "custom_progress", height: 30, map_to: "progress", type: "select", options: [
				{ key: null, label: "Not started" },
				{ key: 0.1, label: "10%" },
				{ key: 0.2, label: "20%" },
				{ key: 0.3, label: "30%" },
				{ key: 0.4, label: "40%" },
				{ key: 0.5, label: "50%" },
				{ key: 0.6, label: "60%" },
				{ key: 0.7, label: "70%" },
				{ key: 0.8, label: "80%" },
				{ key: 0.9, label: "90%" },
				{ key: 1, label: "Complete" }
			]
		},
		{
			name: "resources",
			height: 16,
			type: "resources",
			map_to: "nice"
		},
		{
			name: "period",
			height: 30,
			map_to: { start_date: "start_date", end_date: "end_date" },
			type: "duration",
			time_format: ["%Y", "%m", "%d", "%H:%i"],
		},
		{
			name: "baseline",
			height: 16,
			map_to: { start_date: "start_date_baseline", end_date: "end_date_baseline" },
			button: true,
			type: "duration_optional"
		}
	];

	//gantt.attachEvent("onBeforeLightbox", function (id) {
	//	var task = gantt.getTask(id);
	//	task.resource_template = task.resource_name;
	//	return true;
	//});
}

// Attach functions to the window object to make them globally accessible
window.initGantt = initGantt;