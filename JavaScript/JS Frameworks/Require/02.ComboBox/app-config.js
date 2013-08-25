require.config({
	paths: {
		jquery: "../../scripts/jquery-2.0.3",
		mustache: "../../scripts/mustache",
		class: "../../scripts/class"
	}
});

require(["jquery", "mustache", "controls"], function ($, mustache, c) {
	var people = [
	  { id: 1, name: "Doncho Minkov", age: 18, avatarUrl: "images/minkov.jpg" }, 
	  { id: 2, name: "Georgi Georgiev", age: 19, avatarUrl: "images/joreto.jpg" }];
	  
	var container = $('#content');
	var comboBox = c.controls.ComboBox(people);
	var template = $("#sample-template").html();
	var comboBoxHtml = comboBox.render(template);
	
	var currSelection = $("<div id='selected'>Click to select item.</div>");
	
	container.append(currSelection);
	container.append(comboBoxHtml);
	
	currSelection = $('#selected');
	var list = $('#list');
	list.fadeOut();
	
	list.find('li').click(function() {
		currSelection.html($(this).html());
		list.fadeOut(1000);
	});
	
	currSelection.click(function() {
		if(list.is(':visible')) {
			list.fadeOut(1000);
		}
		else {
			list.fadeIn(1000);
		}
	});
});
