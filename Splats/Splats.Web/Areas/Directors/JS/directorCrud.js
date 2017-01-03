(function () {
	var app = angular.module('director', []);

	app.controller('director', [ '$http', function ($http) {
		var directorCtrl = this;
		directorCtrl.directors = [];

		$http.get("/Directors/Director/DirectorsApi").then(function (response) {
			directorCtrl.directors = response.data.Directors;
		});

	}]);
})();