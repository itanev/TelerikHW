/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
var controls = controls || {};
(function (c) {
	var TableView = Class.create({
		init: function (itemsSource, rows, cols) {
			if (!(itemsSource instanceof Array)) {
				throw "The itemsSource of a TableView must be an array!";
			}
			
			this.itemsSource = itemsSource;
			this.rows = rows;
			this.cols = cols;
		},
		render: function (template) {
			var table = document.createElement("table");
			for(var row = 0; row < this.rows; row += 1) {
				var trItem = document.createElement("tr");
				var item = this.itemsSource[row];
				trItem.innerHTML = template(item);
				table.appendChild(trItem);
			}
			
			return table.outerHTML;
		}
	});
	
	var MarksView = Class.create({
		init: function (marksSource) {
			this.marks = marksSource;
		},
		render: function (template) {
			var table = document.createElement("table");
			var trItem = document.createElement("tr");
			trItem.innerHTML = template(this.marks);
			table.appendChild(trItem);
			
			return table.outerHTML;
		}
	});

	c.getTableView = function (itemsSource, rows, cols) {
		return new TableView(itemsSource, rows, cols);
	}
	c.getMarksView = function(marksSource) {
		return new MarksView(marksSource);
	}
}(controls || {}));