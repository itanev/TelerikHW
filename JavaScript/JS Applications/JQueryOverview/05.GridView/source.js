var gridView = (function() {
	
	function GridView(currTable, gridTableId) {
		var gridViewTable = currTable;
		var gridTableId = gridTableId;
		var hasHeader = false;

		function createGridView (conn, id) {
			$(conn).append("<table id='" + id.substr(1) + "'></table>");
			gridViewTable = $(id);
			gridTableId = id;

			return new GridView(gridViewTable, gridTableId);
		}

		function addHeader() {
			if(hasHeader) return;

			var i = 0;
			gridViewTable.append("<tr></tr>");
			var currTr = $(gridTableId + ' tr:last');
			for(i = 0; i < arguments.length; i += 1) {
				currTr.append("<th>" + arguments[i] + "</th>");
			}

			hasHeader = true;
		}

		function addRow() {
			var i = 0;
			gridViewTable.append("<tr></tr>");
			var currTr = $(gridTableId + ' tbody tr:last');
			for(i = 0; i < arguments.length; i += 1) {
				currTr.append("<td>" + arguments[i] + "</td>");
			}

			return new GridView(gridViewTable, gridTableId);
		}

		return {
			create: createGridView,
			addRow: addRow,
			addHeader: addHeader
		};
	}

	return new GridView;
})();