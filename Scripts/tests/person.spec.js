define(['person/person'], function(Person) {

	describe("Person model", function() {
		it("should use an empty string as default attributes for name", function() {
			var person = new Person();
			expect(person.get("name"))
				.toEqual("");
		});
		
		it("should use 0 as default attributes for age", function() {
			var person = new Person();
			expect(person.get("age"))
				.toEqual(0);
		});

	});
});
	
