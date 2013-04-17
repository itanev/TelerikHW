var tags = ["cms", "javascript", "js", "ASP.NET MVC", ".net", ".net", "css", "wordpress", "xaml", "js", "http", "web", "asp.net", "asp.net MVC", "ASP.NET MVC", "wp", "javascript", "js", "cms", "html", "javascript", "http", "http", "CMS"];

generateTagCloud(tags, 11, 45);

function generateTagCloud(tagsArray, minFontSize, maxFontSize) {
	
	var tagList = [];
	
	var i = 0;
	var index = 0;
	
	//generating list of elements
	for(i = 0; i < tagsArray.length; i++) {
		if((index = contains(tagList, tagsArray[i])) != -1) {
			tagList[index].count++;
		}
		else {
			//creating an object to store element name and count
			var tag = {};
			tag.name = tagsArray[i];
			tag.count = 1;
			
			tagList.push(tag);
		}
	}
	
	//generating actual element and appending it to tagCloud div
	for(i = 0; i < tagList.length; i++) {
		generateElement('p', document.getElementById('tagCloud'), tagList[i], minFontSize, maxFontSize);
	}
}

function generateElement(tag, conn, object, minFontSize, maxFontSize) {
	var element = document.createElement(tag);
	var text = document.createTextNode(object.name);
	
	//just a formula for generating random fontSize
	var randomFontSize = Math.floor(Math.random() * (maxFontSize - object.count - minFontSize) + minFontSize - object.count);
	
	//generating random margin between 1 - 10 px
	var randomMargin = Math.floor(Math.random() * 10 + 1);
	
	element.style.fontSize = randomFontSize + object.count + 'px';
	element.style.position = 'relative';
	element.style.display = 'inline-block';
	element.style.margin = randomMargin + 'px';
	
	element.appendChild(text);
	conn.appendChild(element);
}

//find out index of element if it is contained in given array
function contains(objectsArray, object) {
	var i = 0;
	
	if(objectsArray.length == 0) return -1;
	
	for(i = 0; i < objectsArray.length; i++) {
		if(objectsArray[i].name == object) {
			return i;
		}
	}
	
	return -1;
}
