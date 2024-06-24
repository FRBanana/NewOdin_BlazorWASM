import * as templates from "./templates.js";

export function initGantt() {
    console.log("hello")

    const data = {
        data: [
            { id: 1, text: "Project #2", start_date: "01-04-2023", duration: 18 },
            {
                id: 2, text: "Task #1", start_date: "02-04-2023", duration: 8,
                progress: 0.6, parent: 1
            },
            {
                id: 3, text: "Task #2", start_date: "11-04-2023", duration: 8,
                progress: 0.6, parent: 1
            }
        ],
        links: [
            { id: 1, source: 1, target: 2, type: 1 },
            { id: 2, source: 2, target: 3, type: 0 }
        ]
    }

    initGanttLayout(gantt);

    gantt.init("gantt_here");
    gantt.parse(data);
}

function initGanttLayout(gantt) {
	gantt.config.columns = templates.defaultColumn(gantt);
	gantt.config.resource_property = "nice";
	gantt.config.resource_attribute = "nice-id";
	//gantt.config.resource_render_empty_cells = true;

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

// Attach functions to the window object to make them globally accessible
window.initGantt = initGantt;