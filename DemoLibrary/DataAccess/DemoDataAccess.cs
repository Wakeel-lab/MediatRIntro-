using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.DataAccess
{
    public class DemoDataAccess : IDataAccess
    {
        List<PersonModel> _person = new();

        public DemoDataAccess()
        {
            _person.Add(new PersonModel { Id = 1, FirstName = "John", LastName = "Doe" });
            _person.Add(new PersonModel { Id = 2, FirstName = "Foo", LastName = "Bar" });
        }

        public List<PersonModel> GetPerson()
        {
            return _person.ToList();
        }

        public PersonModel InsertPerson(string firstName, string lastName)
        {

            PersonModel person = new();
            person.FirstName = firstName;
            person.LastName = lastName;

            person.Id = _person.Max(p => p.Id) + 1;

            return person;
        }
    }
}
