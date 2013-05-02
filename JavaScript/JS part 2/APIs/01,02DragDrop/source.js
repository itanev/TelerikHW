var allTrash = document.getElementsByClassName('trash');
var trashCounter = allTrash.length;
var timer,
	startTime,
	endTime,
	elapsedTime;

var trashCan = document.getElementById('conn'),
	startButton = document.getElementById('startButton'),
	newGameButton = document.getElementById('newGameButton'),
	i;
	
var saveScoreBox = document.getElementById('nick'),
	submitScoreButton = document.getElementById('submitScore');

var statistic = document.getElementById('statistic'),
	list = statistic.querySelectorAll('.user');
	
trashCan.addEventListener('mouseout', onMouseOut);
startButton.addEventListener('click', onStartClick);
newGameButton.addEventListener('click', onNewGameClick);
submitScoreButton.addEventListener('click', onClickSubmitScore);

for(i = 0; i < allTrash.length; i += 1) {
	allTrash[i].style.top = generateNumber() + 'px';
	allTrash[i].style.left = generateNumber() + 300 + 'px';
}

// #Drag and drop start.
function allowDrop(ev)
{
	ev.target.src = 'imgs/trash-bucket-open.png';
	ev.preventDefault();
}

function drag(ev)
{
	ev.dataTransfer.setData("Text",ev.target.id);
}

function drop(ev)
{
	ev.preventDefault();
	var data = ev.dataTransfer.getData("Text");
	ev.target.appendChild(document.getElementById(data));
	
	trashCounter -= 1;
	
	if(trashCounter == 0) {
		calcElapsedTime();
		saveScoreBox.style.display = 'block';
	}
}

function calcElapsedTime() {
	timer = new Date();
	endTime = timer.getTime();
	
	elapsedTime = (endTime - startTime) / 1000;
}
// #Drag and drop end.

function saveResult(leading) {
	for(i = 0; i < 5; i += 1) {
		sessionStorage.setItem(leading[i].nick, leading[i].score);
	}
}

function generateNumber() {
	return Math.floor(Math.random() * 500);
}

function getNick() {
	return document.getElementById('name').value;
}

function getLength(obj) {
	return obj.length <= 5 ? obj.length : 5;
}

function getLeading() {
	var leading = [];
	var leadingLength = getLength(sessionStorage);
	
	for(i = 0; i < leadingLength; i += 1) {
		var nick = sessionStorage.key(i);
		var score = sessionStorage.getItem(nick);
		
		leading.push({nick: nick, score: parseFloat(score)});
		
		leading.sort(function(firstScore, secondScore) {
			return firstScore.score - secondScore.score;
		});
	}
	
	return leading;
}

function updateLeading(leading) {
	var pushed = false;
	var userCount = getLength(leading);
	
	for(i = userCount-1; i >= 0; i -= 1) {
		if(parseFloat(leading[i].score) > elapsedTime) {
			leading.splice(i, 0, {nick: getNick(), score: elapsedTime});
			pushed = true;
			break;
		}
	}
	
	if(!pushed && userCount < 5) {
		leading.push({nick: getNick(), score: elapsedTime});
	}
	
	if(leading.length > 5) leading.pop();
	
	return leading;
}

function updateStatistics() {
	var leading = [];
	
	if(sessionStorage.length == 0) {
		leading.push({nick: getNick(), score: elapsedTime});
	}
	else {
		leading = getLeading();
		leading = updateLeading(leading);
	}
	
	sessionStorage.clear();
	
	return leading;
}

function onClickSubmitScore() {
	var leading = updateStatistics();
	
	statistic.style.display = 'block';
	saveScoreBox.style.display = 'none';
	newGameButton.style.display = 'block';
	
	for(i = 0; i < leading.length; i += 1) {
		var userContent = leading[i].nick + ': ' + leading[i].score
		list[i].innerHTML = userContent;
	}
	
	saveResult(leading);
}

function onMouseOut(ev) {
	ev.target.src = 'imgs/trash-bucket-closed.png';
}

function onStartClick(ev) {
	ev.target.style.display = 'none';
	statistic.style.display = 'none';
	
	makeTrashDraggable();
	
	timer = new Date();
	startTime = timer.getTime();
}

function onNewGameClick() {
	location.reload();
}

function makeTrashDraggable() {
	for(i = 0; i < allTrash.length; i += 1) {
		allTrash[i].draggable = true;
	}
}