var movingShapes = (function () {
	var i = 0,
		ellipseMovemendDivs = [],
		rectMovemendDivs = [],
		angle = 0,
		radius = 50,
		rectWidth = 50,
		rectHeight = 200,
		speed = 50;
	
	function add(movement) {
		if(movement == 'rect'){
			rectMovemendDivs.push(generateDiv(rectMovemendDivs));
			addToStage(rectMovemendDivs);
			rectWidth *= rectMovemendDivs.length;
			rectMovemend();
		}
		else if(movement == 'ellipse') {
			ellipseMovemendDivs.push(generateDiv(ellipseMovemendDivs));
			addToStage(ellipseMovemendDivs);
			rectWidth *= ellipseMovemendDivs.length;
			ellipseMovemend();
		}
	}
	
	function addToStage(divs) {
		for(i = 0; i < divs.length; i++) {
			document.body.appendChild(divs[i]);
		}
	}
	
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

	function generateDiv(allDivs) {
		var width = 100;
		var height = 100;

		var leftPos = 50;
		var topPos = 50;

		var borderRadius = 5;
		var borderWidth = 2;

		var div = document.createElement('div');
		var strong = document.createElement('strong'); 
		var strongContent = document.createTextNode('DIV');

		strong.appendChild(strongContent);
		div.appendChild(strong);

		div.style.position = 'absolute';
		div.style.left = leftPos + width * allDivs.length * 2 + 'px';
		div.style.top = topPos + height	+ 'px';
		div.style.margin = 250 + 'px';
		div.style.width = width + 'px';
		div.style.height = height + 'px';
		div.style.backgroundColor = generateColor();
		div.style.border = borderWidth + 'px solid ' + generateColor();
		div.style.borderRadius = borderRadius + 'px';

		return div;
	}
	
	function ellipseMovemend () {
		for(i = 0; i < ellipseMovemendDivs.length; i++) {
			ellipseMovemendDivs[i].style.left = Math.cos(angle + 2 * Math.PI / ellipseMovemendDivs.length * i)/radius * 10000 + 'px';
			
			ellipseMovemendDivs[i].style.top = Math.sin(angle + 2 * Math.PI / ellipseMovemendDivs.length * i)/radius * 7000 + 'px';
		}

		angle = angle + 0.1;

		setTimeout(ellipseMovemend, speed);
	}
	
	function rectMovemend () {
		var leftPos,
			topPos;
			
		for(i = 0; i < rectMovemendDivs.length; i++) {
			leftPos = parseInt(rectMovemendDivs[i].style.left);
			topPos = parseInt(rectMovemendDivs[i].style.top);
			
			if(leftPos < rectWidth && topPos == 0)
				leftPos += 5;
			else if(leftPos == rectWidth && topPos < rectHeight)
				topPos += 5;
			else if(topPos == rectHeight && leftPos > 0)
				leftPos -= 5;
			else
				topPos -= 5;
			
			rectMovemendDivs[i].style.left = leftPos + 'px';
			rectMovemendDivs[i].style.top = topPos + 'px';
		}

		setTimeout(rectMovemend, speed);
	}
	
	return {
		add: add
	};
})();
