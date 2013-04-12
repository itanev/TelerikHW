function checkIfMozilla() {
	var myWindow = window;
	
	var browserName = myWindow.navigator.appCodeName;
	
	var isMozilla = (browserName == "Mozilla");
	
	if(isMozilla) {
		alert("Yes");  
	} else {
		alert("No");  
	}
}
