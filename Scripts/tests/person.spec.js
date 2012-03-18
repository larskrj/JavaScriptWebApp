define(['person/person'], function(Person) {

	describe("Person model", function() {
		it("should expose an default attributes for name to be empty string", function() {
			var person = new Person();
			expect(person.get("name"))
				.toEqual("");
		});
		
		it("should expose an default attributes for age to be 0", function() {
			var person = new Person();
			expect(person.get("age"))
				.toEqual(0);
		});

	});
});
	
