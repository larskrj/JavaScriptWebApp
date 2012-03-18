require.config({
  paths: {
    "order": "require/order",
    "jQuery": "require/require-jQuery",
		"Underscore": "require/require-underscore",
		"Backbone": "require/require-backbone",
		"Handlebars": "require/require-handlebars"
	}
});

require([
  "app",
  "require/order!libs/jquery-1.7.1",
  "require/order!libs/underscore",
  "require/order!libs/backbone",
		"require/order!libs/handlebars",
	"require/order!libs/jquery-pubsub"
	], function (app) {
		app.init();
	});