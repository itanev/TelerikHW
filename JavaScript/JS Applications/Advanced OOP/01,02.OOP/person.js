function Person (firstName, lastName, age) {
	
	this.introduce = function() {
		return "First name: " + firstName + ", Last name: " + lastName + ", Age: " + age;
	};
};