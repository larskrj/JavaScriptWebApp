using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Models;

namespace JavaScriptWebApp.Controllers
{
    public class PersonController : ApiController
    {
    	private static int lastId = 0;
		private static List<Person> persons = new List<Person>();

    	static PersonController()
    	{
			AddPerson(new Person { name = "Ole", age = 14 });
			AddPerson(new Person { name = "Dole", age = 14 });
			AddPerson(new Person { name = "Doffen", age = 14 });
    	}
		
		// GET /api/person
        public IEnumerable<Person> Get()
        {
        	return persons.OrderBy(o => o.id);
        }

        // GET /api/person/5
        public Person Get(int id)
        {
        	var person = persons.FirstOrDefault(o => o.id == id);
			if (person == null)
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound });

        	return person;
        }

        // POST /api/person
        public HttpResponseMessage Post(Person person)
        {
        	AddPerson(person);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, person);
        	response.Headers.Location = new Uri(Request.RequestUri + "/" + person.id);

        	return response;
        }

		// PUT /api/person
        public HttpResponseMessage Put(Person person)
		{
			int index = persons.FindIndex(p => p.id == person.id);
            if (index == -1)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            persons.RemoveAt(index);
            persons.Add(person);

            return Request.CreateResponse(HttpStatusCode.OK, person);
		}
		
    	// DELETE /api/person/5
		public HttpResponseMessage Delete(int id)
        {
			int index = persons.FindIndex(p => p.id == id);
			if (index == -1)
			{
                return Request.CreateResponse(HttpStatusCode.NotFound);
			}
			persons.RemoveAt(index);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    	private static Person FindPerson(int id)
    	{
    		var person = persons.FirstOrDefault(o => o.id == id);
    		if (person == null)
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound });
    		return person;
    	}

    	private static void AddPerson(Person person)
    	{
    		person.id = ++lastId;
    		persons.Add(person);
    	}
    }
}
