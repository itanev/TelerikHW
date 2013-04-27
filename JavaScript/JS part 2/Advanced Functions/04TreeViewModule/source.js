var controls = (function () {
	function treeView(element) {
		// Get the tag, class and id of the conntainter element
		var tag = '', elClass = '', id = '', i, mod = 0;
		
		for( i = 0; i < element.length; i++) {
			if(element[i] == '.')
				mod = 1;
			else if(element[i] == '#') 
				mod = 2;
				
			switch(mod) {
				case 0 :
					tag += element[i];
				break;
				case 1 :
					elClass += element[i];
				break;
				case 2 :
					id += element[i];
				break;
			}
		}
		
		var conn = createElement(tag, elClass, id);
		
		return {
			connElement: conn,
			addNode: addNode,
			content: content
		};
	}
	
	function addNode() {
		var conn = this.connElement;
		var actualConn;
		
		if(conn.tagName == 'LI') {
			actualConn = appendElement.call(conn, 'ul');
		}
		else {
			conn = appendElement.call(conn, 'li');
		}
		
		return {
			connElement: actualConn == undefined ? conn : actualConn,
			addNode: addNode,
			content: content
		};
	}
	
	function content(text) {
		var textNode = document.createTextNode(text);
		this.connElement.appendChild(textNode);
	}
	
	function appendElement(tag) {
		var newElement = document.createElement(tag);
		this.appendChild(newElement);
		return newElement;
	}
	
	function createElement(tag, elClass, id) {
		var element = document.createElement(tag);
		var ul = document.createElement('ul');
		
		element.appendChild(ul);
		
		if(elClass) element.className = elClass.substring(1);
		if(id) element.id = id.substring(1);
		
		document.body.appendChild(element);
		
		return element.querySelector('ul');
	}
	
	return {
		treeView: treeView
	};
})();