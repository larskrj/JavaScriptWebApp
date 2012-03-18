define(["jQuery", "Underscore", "Backbone", "./person", "config"],
	function ($, _, Backbone, Person, config) {
		return Backbone.Collection.extend({
			url: config.apiBaseUrl + "/person",
			model: Person,
			getById: function (id) {
				var person;
				this.each(function (p) {
					if (p.get("id") == id)
						person = p;
				});

				return person;
			}
		});
	}
);