// Slider NameSpace
var slider = (function() {
	var allImgs;
	var visibleImgs = 1;
	// Make visual representation
	function create(imgConn, visibleImgsCount) {
		if(imgConn) {
			var imgs = imgConn.getElementsByTagName("img");
			allImgs = imgs;
			if(visibleImgsCount)
				visibleImgs = visibleImgsCount;
			
			leaveGeneralImgsVisible();
			addSliderArrows(imgConn);
			var slider = new Slider();
		}
	}

	function leaveGeneralImgsVisible() {
		var i = 0;
		for(i = 0; i < allImgs.length - visibleImgs; i += 1) {
			allImgs[i].style.display = "none";
		}
	}

	function addSliderArrows(conn) {
		var leftArrow = document.createElement("div");
		var rightArrow = document.createElement("div");

		leftArrow.className = "arrow";
		rightArrow.className = "arrow";

		leftArrow.id = "left-arrow";
		leftArrow.innerHTML = "Prev";
		conn.appendChild(leftArrow);

		rightArrow.id = "right-arrow";
		rightArrow.innerHTML = "Next";
		conn.appendChild(rightArrow);
	}

	var currIndex = 0;

	var currEnlargedImg = {
		src: "",
		index: undefined
	}

	function makeImageSmall() {
		if(currEnlargedImg.index !== undefined) {
			allImgs[currEnlargedImg.index].src = 
				allImgs[currEnlargedImg.index].src.replace("img", "thumb");
		}
	}

	function Slider() {
		var prev = document.getElementById("left-arrow");
		var next = document.getElementById("right-arrow");

		currIndex = allImgs.length - 1;

		prev.addEventListener("click", this.onClickPrev, false); 
		next.addEventListener("click", this.onClickNext, false); 

		var i = 0;
		for(i = 0; i < allImgs.length; i += 1) {
			allImgs[i].addEventListener("click", this.onImageClick, false);
		}
	}

	Slider.prototype.onImageClick = function(ev) {
		makeImageSmall();

		var i = 0;
		for(i = 0; i < allImgs.length; i += 1) {
			if(allImgs[i] == ev.target) {
				currEnlargedImg.index = i;
				break;
			}
		}

		var thumbSrc = ev.target.src;
		var imgSrc = thumbSrc.replace("thumb", "img");
		ev.target.src = imgSrc;
		currEnlargedImg.src = imgSrc;
	}

	Slider.prototype.onClickPrev = function(ev) {
		makeImageSmall();

		if(currIndex < visibleImgs) {
			return;
		}

		var i = 0;
		for (i = 0; i < visibleImgs; i += 1) {
			allImgs[currIndex - i].style.display = "none";
		};

		currIndex -= 1;

		for(i = 0; i < visibleImgs; i += 1) {
			allImgs[currIndex - i].style.display = "inline";
		}
	}

	Slider.prototype.onClickNext = function(ev) {
		makeImageSmall();
		
		var i = 0;

		if(currIndex >= allImgs.length - 1) {
			return;
		}

		for (i = 0; i < visibleImgs; i += 1) {
			allImgs[currIndex - i].style.display = "none";
		};

		currIndex += 1;

		for(i = 0; i < visibleImgs; i += 1) {
			allImgs[currIndex - i].style.display = "inline";
		}
	}

	return {
		create: create
	}
})();

var conn = document.getElementById("conn");
slider.create(conn, 3);

