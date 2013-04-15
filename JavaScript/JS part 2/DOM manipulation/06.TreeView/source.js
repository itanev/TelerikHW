var liTags = document.getElementsByTagName('li');

var i = 0;

for(i = 0; i < liTags.length; i++) {
	liTags[i].addEventListener('click', revealSubList);
	liTags[i].class = 'expand';
}

function revealSubList(event) {
	//event target and 'this' point to the same object 
	//this === event.target is necessary because otherwise when we click 
	//on one LI item the event will affect the parent LI as well
	if( this === event.target && 
		this.getElementsByTagName('ul')[0].style.display == 'block') {
			this.getElementsByTagName('ul')[0].style.display = 'none';
	}
	else {
		this.getElementsByTagName('ul')[0].style.display = 'block';
	}
}

