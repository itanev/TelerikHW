angular.module('phonecat', [])
	.config(['$routeProvider', function($routeProvider) {
		$routeProvider
			.when('/phones', {templateUrl: 'phone-list.html', controller: PhoneListCtrl})
			.when('/phones:phoneId', {templateUrl: 'phone-detail.html', controller: PhoneDetailsCtrl})
			.otherwise({redirectTo: '/phones'});
		}
	]);