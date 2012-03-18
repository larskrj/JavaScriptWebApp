define(["jQuery", "Underscore", "Backbone", "Handlebars"],
	function ($, _, Backbone, Handlebars) {

		return Backbone.View.extend({
			el: $("#content"),
			template: Handlebars.compile($("#person-edit-template").html()),
			render: function () {
				$(this.el).empty();
				$(this.el).html(this.template(this.model.toJSON()));

				return this;
			},
			events: {
				"click button#savePerson": "savePerson",
				"click button#deletePerson": "deletePerson",
				"click button#cancelEditPerson": "close"
			},
			savePerson: function () {
				this.model.set({ name: $(this.el).find("input#name").val() });
				this.model.set({ age: $(this.el).find("input#age").val() });
				$.support.cors = true; // CORS-støtte for IE8 + IE9
				var self = this;
				
				/*if (!this.model.isValid()) {
					$.publish(app.events.error, [this.model.validate(this.model)]);
					return;
				}*/

				var saveOptions = {
					success: function () {
						$.publish(app.events.message, ["Personen er blitt lagret"]);
						self.close();
					},
					error: function () {
						$.publish(app.events.error, ["Det skjedde en feil ved lagring"]);
					}
				};

				if (this.model.isNew()) {
					this.collection.create(this.model, saveOptions);
				} else {
					this.model.save(null, saveOptions);
				}
			},
			deletePerson: function () {
				var self = this;
				$.support.cors = true; // CORS-støtte for IE8 + IE9
				this.model.destroy({
					success: function () {
						self.close();
						$.publish(app.events.message, ["Personen er blitt slettet"]);
					},
					error: function () {
						$.publish(app.events.error, ["Det skjedde en feil ved sletting"]);
					}
				});
				return false;
			},
			close: function () {
				this.undelegateEvents();
				$.publish(app.events.navigate, ["", { trigger: true}]);
			}
		});
	}
);