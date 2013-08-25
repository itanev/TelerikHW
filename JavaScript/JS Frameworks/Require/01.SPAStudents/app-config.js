require.config({
	paths: {
		jquery: "../scripts/jquery-2.0.3",
		rsvp: "../scripts/rsvp.min",
		httpRequester: "../scripts/http-requester",
		mustache: "../scripts/mustache",
		class: "../scripts/class"
	}
});

require(["jquery", "mustache", "data-persister", "controls"], function ($, mustache, data, c) {
	data.students()
		 .then(function (students) {
			var studentsTemplate = document.getElementById("students-template").innerHTML;
			var marksTemplate = document.getElementById("marks-template").innerHTML;
			
			$("#content").html(getHtml(studentsTemplate, students, c.controls.getStudentsView));
			$('.student').click(function() {
				var id = $(this)[0].id;
				$('#content').html(getHtml(marksTemplate, students[id-1].Marks, c.controls.getMarksView));
			});
			
		}, function (err) {
			console.error(err);
		});
		
	var getHtml = function(template, data, view) {
		var templateFunc = mustache.compile(template);
		var listView = view(data);
		var rendered = listView.render(templateFunc);
		
		return rendered;
	}
});
