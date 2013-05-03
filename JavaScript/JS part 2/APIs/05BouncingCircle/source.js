var circle = document.getElementById('circle'),
	leftBound = 40,
	topBound = 50,
	rightBound = 480,
	bottomBound = 480,
	leftBound = 10,
	topBound = 10,
	speed = 5;

var direction = 'BR';
var circleLeftPos = leftBound,
	circleTopPos = topBound;
	
function move() {
	switch(direction) {
		case 'BR':
			if(circleLeftPos >= rightBound) {
				direction = 'BL';
				bottomLeft();
			}
			else if(circleTopPos >= bottomBound){
				direction = 'TR';
				topRight();
			}
			else {
				bottomRight();
			}
		break;
		case 'BL':
			if(circleLeftPos <= leftBound) {
				direction = 'BR';
				bottomRight();
			}
			else if(circleTopPos >= bottomBound){
				direction = 'TL';
				topLeft();
			}
			else {
				bottomLeft();
			}
		break;
		case 'TR':
			if(circleLeftPos >= rightBound) {
				direction = 'TL';
				topLeft();
			}
			else if(circleTopPos <= topBound){
				direction = 'BR';
				bottomRight();
			}
			else {
				topRight();
			}
		break;
		case 'TL':
			if(circleLeftPos <= leftBound) {
				direction = 'TR';
				topRight();
			}
			else if(circleTopPos <= topBound){
				direction = 'BL';
				bottomLeft();
			}
			else {
				topLeft();
			}
		break;
	}
	
	circle.style.left = circleLeftPos + 'px';
	circle.style.top = circleTopPos + 'px';
	
	setTimeout(move, 30);
}

function bottomRight() {
	circleLeftPos += speed+1;
	circleTopPos += speed;
}

function bottomLeft() {
	circleLeftPos -= speed+1;
	circleTopPos += speed;
}

function topRight() {
	circleLeftPos += speed+1;
	circleTopPos -= speed;
}

function topLeft() {
	circleLeftPos -= speed+1;
	circleTopPos -= speed;
}

move();