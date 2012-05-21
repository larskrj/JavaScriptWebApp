﻿using System;
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
			AddPerson(new Person { Name = "Nils", Age = 23 });
			AddPerson(new Person { Name = "Ole", Age = 41 });
    	}
		
		// GET /api/person
        public IEnumerable<Person> Get()
        {
        	return persons.OrderBy(o => o.Id);
        }

        // GET /api/person/5
        public Person Get(int id)
        {
        	var person = persons.FirstOrDefault(o => o.Id == id);
			if (person == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

        	return person;
        }

        // POST /api/person
        public HttpResponseMessage<Person> Post(Person person)
        {
        	AddPerson(person);
        	var response = new HttpResponseMessage<Person>(person, HttpStatusCode.Created);
        	response.Headers.Location = new Uri(Request.RequestUri + "/" + person.Id);

        	return response;
        }

		// PUT /api/person
		public void Put(Person person)
		{
			int index = persons.FindIndex(p => p.Id == person.Id);
            if (index == -1)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            persons.RemoveAt(index);
            persons.Add(person);
		}
		
    	// DELETE /api/person/5
		public void Delete(int id)
        {
			int index = persons.FindIndex(p => p.Id == id);
			if (index == -1)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			persons.RemoveAt(index);
        }

    	private static Person FindPerson(int id)
    	{
    		var person = persons.FirstOrDefault(o => o.Id == id);
    		if (person == null)
    			throw new HttpResponseException(HttpStatusCode.NotFound);
    		return person;
    	}

    	private static void AddPerson(Person person)
    	{
    		person.Id = ++lastId;
    		persons.Add(person);
    	}
    }
}
