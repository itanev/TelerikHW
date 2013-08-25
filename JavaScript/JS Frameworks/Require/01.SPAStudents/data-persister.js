define(["httpRequester"], function (httpRequester) {
	function getStudents() {		
		return httpRequester.getJSON("http://localhost:50700/api/students");
	}
	return {
		students: getStudents
	}
});