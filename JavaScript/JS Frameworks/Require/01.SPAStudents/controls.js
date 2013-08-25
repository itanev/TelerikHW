define(["class"], function (Class) {
	var controls = controls || {};
	(function (c) {
		var ListView = Class.create({
			init: function (itemsSource) {
				if (!(itemsSource instanceof Array)) {
					throw "The itemsSource of a ListView must be an array!";
				}
				
				this.itemsSource = itemsSource;
			},
			render: function (template) {
				var ul = document.createElement("ul");
				for(var row = 0; row < this.itemsSource.length; row += 1) {
					var item = this.itemsSource[row];
					var li = template(item);
					ul.innerHTML += li;
				}
				
				return ul.outerHTML;
			}
		});

		var MarksView = Class.create({
			init: function (marksSource) {
				this.marks = marksSource;
			},
			render: function (template) {
				var ul = document.createElement("ul");
				for(var row = 0; row < this.marks.length; row += 1) {
					var item = this.marks[row];
					var li = template(item);
					ul.innerHTML += li;
				}
				
				return ul.outerHTML;
			}
		});

		c.getStudentsView = function (itemsSource) {
			return new ListView(itemsSource);
		}
		c.getMarksView = function(marksSource) {
			return new MarksView(marksSource);
		}
	}(controls || {}));
	
	return {
		controls: controls
	};
});