define(["class", "mustache", "jquery"], function (Class, mustache, $) {
	var controls = controls || {};
	(function (c) {
		var ComboBox = Class.create({
			init: function (itemsSource) {
				if (!(itemsSource instanceof Array)) {
					throw "The itemsSource of a ListView must be an array!";
				}
				
				this.itemsSource = itemsSource;
			},
			render: function (template) {
				var ul = document.createElement("ul");
				ul.id = 'list';
				var getHtml = mustache.compile(template);
				for(var row = 0; row < this.itemsSource.length; row += 1) {
					var item = this.itemsSource[row];
					var li = document.createElement('li');
					li.innerHTML = getHtml(item);
					ul.appendChild(li);
				}
				
				return ul.outerHTML;
			}
		});

		c.ComboBox = function (itemsSource) {
			return new ComboBox(itemsSource);
		}
	}(controls || {}));
	
	return {
		controls: controls
	};
});