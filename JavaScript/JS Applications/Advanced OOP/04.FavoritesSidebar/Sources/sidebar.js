var sidebar = (function() {
	function Folder(title) {
		var title = title;
		var urls = [];

		this.addUrl = function(url) {
			urls.push(url);
		}

		this.display = function(conn) {
			var folder = document.createElement("ul");
			var folderTitle = document.createElement("h3");
			folderTitle.innerHTML = title;

			conn.appendChild(folderTitle);

			var i = 0;
			for(i = 0; i < urls.length; i += 1) {
				var li = document.createElement("li");
				var url = document.createElement("a");
				url.href = urls[i].getUrl();
				url.target = "_blank";
				url.innerHTML = urls[i].getTitle();
				li.appendChild(url);
				folder.appendChild(li);
			}

			conn.appendChild(folder);
		}

		this.getUrlsAsArray = function() {
			return urls;
		}

		this.getTitle = function () {
			return title;
		}
	}

	function Url(title, url) {
		var title = title;
		var url = url;

		this.getTitle = function() {
			return title;
		}

		this.getUrl = function() {
			return url;
		}

		this.display = function(conn) {
			var a = document.createElement("a");
			a.href = url;
			a.target = "_blank";
			a.innerHTML = title;

			conn.appendChild(a);
		}
	}

	return {
		Folder: Folder,
		Url: Url
	}
})();

var conn = document.getElementById("favorites");
var url = new sidebar.Url("Data", "http://data.bg");
var url1 = new sidebar.Url("Data", "http://data.bg");
var url2 = new sidebar.Url("Data", "http://data.bg");
var url3 = new sidebar.Url("Data", "http://data.bg");
var folder = new sidebar.Folder("Pesho");
folder.addUrl(url);
folder.addUrl(url1);
folder.addUrl(url2);
folder.addUrl(url3);
folder.display(conn);

var anotherFolder = new sidebar.Folder("Stamat");
anotherFolder.addUrl(url2);
anotherFolder.addUrl(url1);
anotherFolder.addUrl(url3);
anotherFolder.addUrl(url);
anotherFolder.display(conn);

url.display(conn);