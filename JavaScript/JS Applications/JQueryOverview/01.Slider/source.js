var slider = (function () {
	var time = 5000;
	var parent = $("#slider");
	var children = parent.children();
	var childIndex = 0;
	var animated = false;

	var initialize = function(changeTime) {
		if(changeTime) time = changeTime;
		children.hide();
		showChild(childIndex);

		var timer = changeOnTime(time);

		parent.append($("<button>Prev</button>").click(function(ev) {
			if(animated) return;
			animated = true;
			if(childIndex > 0) {
				clearInterval(timer);
				timer = changeOnTime(time);
				hideChild(childIndex);
				childIndex--;	
				showChild(childIndex);
			}
		}));

		parent.append($("<button>Next</button>").click(function() {
			if(animated) return;
			animated = true;
			if(childIndex < children.length - 1) {
				clearInterval(timer);
				timer = changeOnTime(time);
				hideChild(childIndex);
				childIndex++;
				showChild(childIndex);
			}
		}));
	}

	function changeOnTime(time) {
		if(!time) var time = 5000;
		var direction = 'farward';
		var currInterval = setInterval(function() {
			hideChild(childIndex);

			if(childIndex == 0) {
				direction = 'farward';
			}
			else if(childIndex == children.length - 1) {
				direction = 'backward';
			}

			if(direction == 'farward') {
				childIndex++;
			}
			else {
				childIndex--;
			}

			showChild(childIndex);
		}, time);

		return currInterval;
	}

	function showChild(index) {
		var currVisibleElement = children.eq(index);
		setTimeout(function() {
			currVisibleElement.fadeIn(1000, function() {animated = false;});
		}, 1000);
	}

	function hideChild(index){
		var currHiddenElement = children.eq(index);
		currHiddenElement.fadeOut(1000, function() {animated = false;});
	}

	return {
		init: initialize
	};
})();

slider.init(5000);