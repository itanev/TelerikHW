function Student(firstName, lastName, age, grade) {
	this.firstName = firstName;
	this.lastName = lastName;
	this.age = age;
	this.grade = grade;
	
	Person.apply(this, arguments);
	
	var baseIntroduce = this.introduce;
	
	this.introduce = function () {
		return baseIntroduce() + " Grade: " + grade;
	};
}

Student.prototype = new Person();
Student.prototype.constructor = Student;