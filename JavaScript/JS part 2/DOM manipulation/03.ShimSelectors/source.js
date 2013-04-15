if(typeof document.querySelector == 'undefined') {
	document.querySelector = querySelector;
}

if(typeof document.querySelectorAll == 'undefined') {
	document.querySelectorAll = querySelectorAll;
}

alert(document.querySelector('div').innerHTML);

function contains(string, symbol, fromIndex) {
	if(!fromIndex) fromIndex = 0;
	
	var i = fromIndex;
	var index = -1;
	
	for(i = fromIndex; i < string.length; i++) {
		if(string[i] == symbol) {
			index = i;
			break;
		}
	}
	
	return index;
}

function split(string, symbols) {
	var i = 0; 
	var selectors = [];
	var selector = '';
	
	for(i = 0; i < string.length; i++) {
		if(i == 0) {
			selector += string[i];
			continue;
		}
		
		if(contains(symbols, string[i]) != -1) {
			selectors.push(selector);
			//getting rid of empty spaces
			selector = (string[i] == ' ') ? '' : string[i];
		}
		else {
			selector += string[i];
		}
	}
	
	selectors.push(selector);
	
	//getting rid of empty elements
	var actualSelectors = [];
	
	for(i = 0; i < selectors.length; i++) {
		if( selectors[i] != '' &&
			contains(symbols, selectors[i]) == -1) {
				actualSelectors.push(selectors[i]);
		}
	}
	
	return actualSelectors;
}

function selectElementsByTagName(target, tag) {
	var resultElements = [];
	
	if(target == document)
		resultElements = document.getElementsByTagName(tag);
	else {
		var i = 0;
		
		for(i = 0; i < target.length; i++) 
			if(target[i].tagName == tag) 
				resultElements.push(target[i]);
	}	
	
	return resultElements;
}

function selectElementsByClassName(target, nameOfClass) {
	var resultElements = [];
	
	nameOfClass = nameOfClass.substr(1);
	
	if(target == document)
		resultElements = document.getElementsByClassName(nameOfClass);
	else {
		var i = 0;
		
		for(i = 0; i < target.length; i++) 
			if(target[i].className == nameOfClass) 
				resultElements.push(target[i]);
	}	
	
	return resultElements;
}

function selectElementsById(target, id) {
	var resultElements = [];
	
	id = id.substr(1);
	
	if(target == document)
		resultElements.push(document.getElementById(id));
	else {
		var i = 0;
		
		for(i = 0; i < target.length; i++) 
			if(target[i].id == id) 
				resultElements.push(target[i]);
	}	
	
	return resultElements;
}

function selectElementsByPseudo(target, pseudo) {
	if(!pseudo) return target;
	
	pseudo = pseudo.substr(1);
	
	if(pseudo == 'first-child' || pseudo == 'first') {
		if(target == document) return document.firstChild;
		else return target[0];
	}
	else if(pseudo == 'last-child' || pseudo == 'last') {
		if(target == document) return document.lastChild;
		else return target[target.length-1];
	}
	
	return target;
}

function querySelectorAll(selector) {
	var selectors = split(selector, '.# :');
	
	var target = document;
	var i = 0;
	
	//execute selectors
	for(i = 0; i < selectors.length; i++) {
		if(selectors[i][0] == '.') target = selectElementsByClassName(target, selectors[i]);
		else if(selectors[i][0] == '#') target = selectElementsById(target, selectors[i]);
		else if(selectors[i][0] == ':') target = selectElementsByPseudo(target, selectors[i]);
		else target = selectElementsByTagName(target, selectors[i]);
	}
	
	return target;
}

//just reusing the querySelectorAll function
function querySelector(selector) {
	var result = querySelectorAll(selector);
	
	if(typeof result.length == 'undefined') {
		return result;
	}
	else {
		return result[0];
	}
}
