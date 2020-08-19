using System;
using System.Collections.Generic;

namespace Entities.ExplicitConstructorsParameterless
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public IReadOnlyList<Person> Children { get; set; }

        public Person()
        {
        }
    }
}