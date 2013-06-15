var boundElement = $("#someElement");
var beforeElement = createDomElement("div", "before");
var afterElement = createDomElement("div", "after");
boundElement.before(beforeElement);
boundElement.after(afterElement);

function createDomElement(element, content) {
	return $(document.createElement(element)).append(content);
}