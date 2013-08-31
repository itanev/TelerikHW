function PhoneListCtrl($scope) {
	$scope.phones = [{name: "phone6", snippet: "This is phone 1"},
					{name: "phone2", snippet: "This is phone 2"},
					{name: "phone3", snippet: "This is phone 3"},
					{name: "phone4", snippet: "This is phone 4"},
					{name: "phone5", snippet: "This is phone 5"}];
					
	$scope.orderProp = 'name';
}

function PhoneDetailsCtrl($scope, $routeParams) {
	$scope.phoneId = $routeParams.phoneId;
}
