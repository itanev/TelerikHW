function validateForm() {
	var form = document.forms["calc"];
	var firstNumber = form["firstNumber"].value;
	var secondNumber = form["secondNumber"].value;
	var sign = form["sign"].value;
	
	var firstNumberLabel = document.getElementById('fNumLabel');
	var secondNumberLabel = document.getElementById('sNumLabel');
	var signLabel = document.getElementById('signLabel');
	
	if(!isValid(firstNumber)) {
		setColor(firstNumberLabel, 'red');
		setColor(secondNumberLabel, 'black');
		setColor(signLabel, 'black');
		return false;
	}
	else if(!isValid(secondNumber)) {
		setColor(secondNumberLabel, 'red');
		setColor(firstNumberLabel, 'black');
		setColor(signLabel, 'black');
		return false;
	}
	else if(!isValidSign(sign)) {
		setColor(signLabel, 'red');
		setColor(firstNumberLabel, 'black');
		setColor(secondNumberLabel, 'black');
		return false;
	}
	
	return true;
}

function setColor(label, color) {
	if(label && color) label.style.color = color;
}

function isValid(number) {
	
	if(number != '' && !isNaN(number)) {
		return true;
	}
	
	return false;
}

function isValidSign(sign) {
	if( sign == '+' ||
		sign == '-' ||
		sign == '*' ||
		sign == '/' ||
		sign == '%' ) {
			return true;
	}
	
	return false;
}