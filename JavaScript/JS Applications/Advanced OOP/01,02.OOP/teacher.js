function Teacher(firstName, lastName, age, speciality) {
	this.firstName = firstName;
	this.lastName = lastName;
	this.age = age;
	this.speciality = speciality;
	
	Person.apply(this, arguments);
	
	var baseIntroduce = this.introduce;
	
	this.introduce = function () {
		return baseIntroduce() + " Speciality: " + speciality;
	};
}

Teacher.prototype = new Person();
Teacher.prototype.constructor = Teacher;