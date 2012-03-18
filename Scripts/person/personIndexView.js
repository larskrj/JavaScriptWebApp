define(["jQuery", "Underscore", "Backbone", "Handlebars"],
	function ($, _, Backbone, Handlebars) {
		return Backbone.View.extend({
			el: $("#content"),
			template: Handlebars.compile($("#person-index-template").html()),
			render: function () {
				$(this.el).empty();
				var js = { persons: this.collection.toJSON() };
				$(this.el).html(this.template(js));
				return this;
			}
		});
	}
);