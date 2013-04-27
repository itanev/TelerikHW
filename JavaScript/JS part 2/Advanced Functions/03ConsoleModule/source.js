var specialConsole = (function() {
	(function () {
		var consoleConn = document.createElement('div');
		
		consoleConn.id = 'specialConsole';
		consoleConn.style.backgroundColor = '#000';
		consoleConn.style.color = '#fff';
		consoleConn.style.border = '1px solid #888';
		consoleConn.style.padding = '20px';
		
		document.body.appendChild(consoleConn);
	})();
	
	var console = document.getElementById('specialConsole');

	function getMessage(args) {
		var msg = args[0];
		var i,
			numStr;
		
		for(i = 1; i < args.length; i++) {
			numStr = '{' + parseInt(i-1) + '}';
			msg = msg.replace(numStr, args[i]);
		}
		
		return msg.toString();
	}
	
	function writeLine() {
		var msg = getMessage(arguments);
		
		var p = document.createElement('p');
		var text = document.createTextNode(msg);
		
		p.appendChild(text);
		p.style.color = '#fff';
		
		console.appendChild(p);
	}
	
	function writeError() {
		var errorMsg = getMessage(arguments);
		
		var p = document.createElement('p');
		var text = document.createTextNode(errorMsg);
		
		p.appendChild(text);
		p.style.color = 'red';
		p.style.fontWeight = 'bold';
		
		console.appendChild(p);
	}
	
	function writeWarning() {
		var warningMsg = getMessage(arguments);
		
		var p = document.createElement('p');
		var text = document.createTextNode(warningMsg);
		
		p.appendChild(text);
		p.style.color = 'yellow';
		p.style.fontWeight = 'bold';
		
		console.appendChild(p);
	}
	
	return {
		writeLine: writeLine,
		writeError: writeError,
		writeWarning: writeWarning
	};
})();