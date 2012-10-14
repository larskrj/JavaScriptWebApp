//globals: 

define(["jQuery",
		"Underscore",
		"Backbone",
		"./person",
		"./persons",
		"./personIndexView",
		"./personEditView"],
	function ($, _, Backbone, Person, Persons, IndexView, EditView) {
		var personList;

		function message(text) {
			$("h2").html(text);
		}

		function init(callback) {
			$("h2").html("Personer");
			$.support.cors = true; // CORS-støtte for IE8 + IE9
			personList = new Persons();
			personList.fetch({ success: callback });
		}

		function index() {
			var view = new IndexView({ collection: personList });
			view.render();
		}

		function edit(id) {
			var person = personList.getById(id);
			if (!person) {
				message("Finner ikke personen!");
				return;
			}

			var view = new EditView({ model: person, collection: personList });
			view.render();
			$("fieldset legend").html("Endre person");
		}

		function add() {
			console.log("add");
			var view = new EditView({ model: new Person(), collection: personList });
			view.render();
			$("fieldset legend").html("Opprett ny person");
		}

		return {
			add: add,
			init: init,
			index: index,
			edit: edit
		};
	});
