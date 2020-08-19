using System;
using System.Collections.Generic;

namespace Entities.PrivateConstructors
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public IReadOnlyList<Person> Children { get; set; }

        private Person()
        {
        }
    }
}