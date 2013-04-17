function generateRandomNumber(to, from) {
	if(!from) from = 0;
	if(!to) to = 100;
	
	return Math.floor(Math.random() * (to - from) + from);
}

function generateColor() {
	var randomRed = generateRandomNumber(255);
	var randomGreen = generateRandomNumber(255);
	var randomBlue = generateRandomNumber(255);
	
	return 'rgb(' + randomRed + ',' + randomGreen + ',' + randomBlue + ')';
}


function generateDiv() {
	var randomWidth = generateRandomNumber(100, 20);
	var randomHeight = generateRandomNumber(100, 20);

	var leftPos = generateRandomNumber(window.innerWidth);
	var topPos = generateRandomNumber(window.innerHeight);

	var randomBorderRadius = generateRandomNumber(100, 1);
	var randomBorderWidth = generateRandomNumber(20, 1);

	var div = document.createElement('div');
	var strong = document.createElement('strong'); 
	var strongContent = document.createTextNode('DIV');

	strong.appendChild(strongContent);
	div.appendChild(strong);

	div.style.position = 'absolute';
	div.style.left = leftPos + 'px';
	div.style.top = topPos + 'px';
	div.style.width = randomWidth + 'px';
	div.style.height = randomHeight + 'px';
	div.style.backgroundColor = generateColor();
	div.style.border = randomBorderWidth + 'px solid ' + generateColor();
	div.style.borderRadius = randomBorderRadius + 'px';

	document.body.appendChild(div);
}

var i = 0;
for(i = 0; i < 10; i++) {
	generateDiv();
}