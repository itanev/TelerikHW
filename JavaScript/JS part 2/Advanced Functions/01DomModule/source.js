var domModule = (function () {
	var i, j,
		bufferSize = 1,
		bufferElements = [],
		buffer = {
			parentSelector: undefined,
			elements: [],
		};	
		
	function appendChild(element, selector) {
		var parent = document.querySelector(selector);
		parent.appendChild(element);
	}

	function removeChild(tag, optionalSelector) {
		if(tag) {
			var elements = document.querySelectorAll(tag);
			var childElements;
			
			if(optionalSelector) {
				optionalSelector = finishSelectorIfNecessary(optionalSelector);
				
				for(i = 0; i < elements.length; i++) {
					childElements = elements[i].querySelectorAll(optionalSelector);
					
					for(j = 0; j < childElements.length; j++) {
						elements[i].removeChild(childElements[j]);
					}
				}
			}
			else {
				for(i = 0; i < elements.length; i++) {
					document.body.removeChild(elements[i]);
				}
			}
		}
	}

	function addHandler(selector, eventType, eventHandler) {
		selector = finishSelectorIfNecessary(selector);
		
		var elements = document.querySelectorAll(selector);
		
		for(i = 0; i < elements.length; i++) {
			elements[i].addEventListener(eventType, eventHandler);
		}
	}

	function appendToBuffer(selector, element) {
		var found = false;
		var i;
		
		for(i = 0; i < bufferElements.length; i++) {
			if(bufferElements[i].parentSelector == selector) {
				found = true;
				break;
			}
		}
		
		if(found) {
			bufferElements[i].elements.push(element);
		}
		else {
			buffer.parentSelector = selector;
			buffer.elements.push(element);
			bufferElements.push(buffer);
		}
		
		if(bufferElements[i].elements.length == bufferSize) {
			appendElements(bufferElements[i].parentSelector, bufferElements[i].elements);
			
			bufferElements[i].elements = [];
			buffer.parentSelector = undefined;
		}
	}

	function getElements(selector) {
		return document.querySelectorAll(selector);
	}
	
	function appendElements(selector, elements) {
		var parentElements = document.querySelectorAll(selector);
		
		for(i = 0; i < parentElements.length; i++) {
			for(j = 0; j < elements.length; j++) {
				parentElements[i].appendChild(elements[j]);
			}
		}
	}
	
	function finishSelectorIfNecessary(selector) {
		if(selector.indexOf('child') != -1) return selector;
		
		if( selector.indexOf(':first') != -1 || 
			selector.indexOf(':last') != -1 ||
			selector.indexOf(':nth') != -1 ) {
				return selector + '-child';
		}
	}
	
	return {
		appendChild: appendChild,
		removeChild: removeChild,
		addHandler: addHandler,
		appendToBuffer: appendToBuffer,
		getElements: getElements
	}
})();
