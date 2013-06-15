var students = [];
students.push({firstName: "pesho", lastName: "goshov", grade: 6});
students.push({firstName: "kiro", lastName: "peshev", grade: 5});
students.push({firstName: "stamat", lastName: "ivanov", grade: 1});
students.push({firstName: "gosho", lastName: "kirov", grade: 9});
students.push({firstName: "ivan", lastName: "stamatov", grade: 11});

function generateTable(students) {
	if(!students) return;

	$(document.body).append("<table id='students'></table>");
	var table = $("#students");
	table.append("<thead><tr></tr></thead>");
	var thead = $('#students thead tr');

	$.each(students[0], function(key){
		thead.append("<th>" + key + "</th>");
	}); 

	var i = 0;
	for(i = 0; i < students.length; i += 1) {
		table.append("<tr></tr>");
		var row = $("#students tr:last");
		$.each(students[i], function(key, val) {
			row.append("<td>" + val + "</td>");
		});
	}

	table.css("border", "1px solid black");
	$("#students td").css("border", "1px solid black");
}

generateTable(students);