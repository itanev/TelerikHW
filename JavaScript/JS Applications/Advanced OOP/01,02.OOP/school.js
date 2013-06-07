var classes = [];

classes.push({	
		students: [
			new Student("Pesho", "Petrov", 21, 2),
			new Student("Kiro", "Petrov", 21, 2),
			new Student("Tosho", "Petrov", 21, 2),
			new Student("Gosho", "Petrov", 21, 2),
			new Student("Tisho", "Petrov", 21, 2),
			new Student("Stamat", "Petrov", 21, 2),
			new Student("Ivan", "Petrov", 21, 2),
		],
		formTeacher: new Teacher("Maria", "Geshova", 34, "Math")
	}
);

classes.push({	
		students: [
			new Student("Pesho", "Petrov", 31, 2),
			new Student("Kiro", "Petrov", 31, 2),
			new Student("Tosho", "Petrov", 31, 2),
			new Student("Gosho", "Petrov", 31, 2),
			new Student("Tisho", "Petrov", 31, 2),
			new Student("Stamat", "Petrov", 31, 2),
			new Student("Ivan", "Petrov", 31, 2),
		],
		formTeacher: new Teacher("Maria", "Geshova", 34, "Math")
	}
);

// Namespace for data encapsulation.
var schoolNS = (function() {
	function School(name, town, classes){
		this.name = name;
		this.town = town;
		this.classes = classes;
		
		function getClasses() {
			var classInfo = "";
			var i = 0, j = 0;
			for(i = 0; i < classes.length; i += 1) {
				classInfo += "<br /><hr />Form Teacher: " + classes[i].formTeacher.introduce();
				for(j = 0; j < classes[i].students.length; j += 1) {
					classInfo += "<br />Student: " + classes[i].students[j].introduce();
				}
			}
			
			return classInfo;
		}
		
		this.getClasses = getClasses;
		
		// Classical OOP.
		// this.getInfo = function() {
			// return 	"Name: " + this.name + "<br />" + 
					// "Town: " + this.town + "<br />" +
					// "Classes: " + this.getClasses();
		// }
	}
	
	// Prototypal OOP.
	School.prototype.getInfo = function() {
		return 	"Name: " + this.name + "<br />" + 
				"Town: " + this.town + "<br />" +
				"Classes: " + this.getClasses();
	}
	
	return {
		School: School
	}
})();


