define(["jQuery", "Underscore", "Backbone", "config"],
	function ($, _, Backbone, config) {
		return Backbone.Model.extend({
			defaults: {
				"id": null,
				"name": "",
				"age": 0
			},
			initialize: function (arg) {
				if (arg && _.isArray(arg)) {
					this.set({ name: arg.name });
					this.set({ age: arg.age });
					this.set({ id: arg.id });
				}
			},
			/*validate: function (attrs) {
				if (!attrs.age) {
					return "Alder må være et nummer mellom 0 og 120";
				}
				if (!attrs.name) {
					return "Navn må fylles ut";
				}
				return null;
			},*/
			urlRoot: config.apiBaseUrl + "/person"
		});
	}
);