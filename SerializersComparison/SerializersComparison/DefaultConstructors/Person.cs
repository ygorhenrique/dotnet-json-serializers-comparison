using System;
using System.Collections.Generic;

namespace Entities.DefaultConstructors
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public IReadOnlyList<Person> Children { get; set; }
    }
}