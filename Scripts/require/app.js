define([
  "jQuery",
	"Underscore",
	"Backbone",
	"person/personController"
], function ($, _, Backbone, personController) {
	var app = window.app = this.app || {};
	app.events = {
		navigate: "app.naviage",
		message: "app.message",
		error: "app.error"
	};

	function errorMessage(text) {
		message(text, "error");
	}

	function message(text, type) {
		if (!type) type = "success";
		var messageHtml = $("<div class='alert alert-" + type + "'>" + text + "</div>");
		$("#messages").html(messageHtml);
		messageHtml.delay(2000).fadeOut('slow');
	}

	function init() {
		$.support.cors = true; // CORS-støtte for IE8 + IE9

		var AppRouter = Backbone.Router.extend({
			routes: {
				"": "index",
				"add": "add",
				"edit/:id": "edit"
			},
			index: function () {
				personController.index();
			},
			add: function () {
				personController.add();
			},
			edit: function (id) {
				personController.edit(id);
			}
		});
		
		personController.init(function () {
			var appRouter = new AppRouter();
			Backbone.history.start();
			$.subscribe(app.events.navigate, appRouter.navigate);
			$.subscribe(app.events.message, message);
			$.subscribe(app.events.error, errorMessage);
		});
	}

	return {
		init: init
	};
});


