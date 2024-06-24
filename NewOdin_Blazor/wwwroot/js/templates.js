// Templates and Structures

export function defaultColumn(gantt) {
	var taskBackgroundEditor = { type: "text", map_to: "background" };
	var chart = [
		{
			name: "overdue", label: "", min_width: 30, max_width: 30, template: function (order) {
				if (order.is_delayed) {
					return '<div class="overdue-indicator">!</div>';
				}
				return '<div></div>';
			}
		},
		{
			name: "order_name",
			label: "Order name",
			min_width: 200,
			width: 300,
			tree: true,
			resize: true,
			hide: false,
			template: function (obj) {
				//var placeholder;
				//if (obj.layer === 1) {
				//	placeholder = "Layer 1 " + obj.text;
				//} else if (obj.layer === 2) {
				//	placeholder = "Layer 2 " + obj.text;
				//} else if (obj.layer === 5) {
				//	placeholder = "Layer 5 " + ;
				//}

				return obj.text;
			}
		},
		{
			name: "resource_name", align: "center", width: 350,
			resize: true,
			label: "Resource Name", template: function (task) {
				if (task.type == gantt.config.types.project) {
					return "";
				}
				const resources = gantt.getTaskResources(task.id);
				if (!resources.length) {
					return "Unassigned";
				} else if (resources.length === 1) {
					return resources[0].text;
				} else {
					var final = resources.map(item => item.text).join(', ');
					return final;
				}
			},
		},
		{
			name: "start_date",
			label: "Start Date",
			width: "*",
			resize: true,
			hide: true
		},
		{
			name: "resource_group",
			label: "Resource Group",
			width: "*",
			tree: true,
			resize: true,
			hide: true,
			template: function (obj) {
				return obj.text
			}
		},
		{
			name: "resource_name",
			label: "Resource Name",
			align: "center",
			resize: true,
			width: "*",
			hide: true
		},
		{
			name: "background",
			label: "Background",
			min_width: 100,
			resize: true,
			editor: taskBackgroundEditor
		},
		//{ name: "is_delayed", label: "Delayed", align: "center", width: 80 },
		//{ name: "color", label: "Color", align: "center", width: 60 },
		//{ name: "type", label: "Type", align: "center", width: 60 },
		//{ name: "status", label: "Status", align: "center", width: 60 },
		{ name: "add", label: "", width: 36 }
	];

	return chart
}

export function resourceLoadChart(gantt) {
	function getDuration(tasks, resource, start_date, end_date) {
		let result = 0;
		tasks.forEach(function (item) {
			// Get the assignment
			const assignments = gantt.getResourceAssignments(resource.id, item.id);
			assignments.forEach(function (assignment) {
				result += Number(8 * assignment.value);
			});
			
		});

		return result;
	}

	gantt.templates.resource_cell_value = function (start_date, end_date, resource, tasks) {
		var val = getDuration(tasks, resource, start_date, end_date);

		return val;
	};

	var chart = {
		columns: [
			{
				name: "name", label: "Name", tree: true, template: function (resource) {
					return resource.text;
				}
			},
		]
	};

	return chart;
}

export function resourceCapacityChart(gantt) {
	function getResourceAssignments(resourceId) {
		let assignments;
		const store = gantt.getDatastore(gantt.config.resource_store);
		if (store.hasChild(resourceId)) {
			assignments = [];
			store.getChildren(resourceId).forEach(function (childId) {
				assignments = assignments.concat(gantt.getResourceAssignments(childId));
			});
		} else {
			assignments = gantt.getResourceAssignments(resourceId);
		}
		return assignments;
	}

	const cap = {};

	function getAllocatedValue(tasks, resource) {
		let result = 0;
		tasks.forEach(function (item) {
			const assignments = gantt.getResourceAssignments(resource.id, item.id);
			assignments.forEach(function (assignment) {
				result += Number(assignment.value);
			});
		});
		return result;
	}

	function getCapacity(date, resource) {
		if (gantt.$resourcesStore.hasChild(resource.id)) {
			return -1;
		}

		return resource.capacity;
	}

	// Cell Values
	gantt.templates.histogram_cell_label = function (start_date, end_date, resource, tasks) {
		if (tasks.length && !gantt.$resourcesStore.hasChild(resource.id)) {
			var val = getAllocatedValue(tasks, resource) + "/" + getCapacity(start_date, resource);
			return val;
		} else {
			if (!gantt.$resourcesStore.hasChild(resource.id)) {
				return '&ndash;';
			}
			return '';
		}
	};
	gantt.templates.histogram_cell_allocated = function (start_date, end_date, resource, tasks) {
		var val = getAllocatedValue(tasks, resource);

		return val;
	};

	gantt.templates.histogram_cell_capacity = function (start_date, end_date, resource, tasks) {
		if (!gantt.isWorkTime(start_date)) {
			return 0;
		}
		return getCapacity(start_date, resource);
	};

	var chart = {
		columns: [
			{
				name: "name", label: "Resource Items", tree: true, template: function (resource) {
					return resource.text;
				}
			},
			{
				name: "progress", label: "Complete", align: "center", template: function (resource) {
					let totalToDo = 0,
						totalDone = 0;

					const assignments = getResourceAssignments(resource.id);

					assignments.forEach(function (assignment) {
						const task = gantt.getTask(assignment.task_id);
						totalToDo += task.duration;
						totalDone += task.duration * (task.progress || 0);
					});

					let completion = 0;
					if (totalToDo) {
						completion = (totalDone / totalToDo) * 100;
					}

					return Math.floor(completion) + "%";
				}, resize: true
			},
		]
	}

	return chart;
}