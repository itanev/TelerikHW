(function ($) {

	$.fn.treeView = function(options) {

		var settings = $.extend({
			conn: "ul",
			sublists: "ul"
		}, options);

		$(settings.conn + " li").each(function () {
			$(this).click(revealSubList);
		});

		function revealSubList(ev) {
			if(!settings.sublists) return 0;

			if( this === ev.target && 
				$(this).children(settings.sublists).css('display') == 'block') {
					$(this).children(settings.sublists).css('display', 'none');
			}
			else {
				$(this).children(settings.sublists).css('display', 'block')
			}
		}

	};

})(jQuery);
