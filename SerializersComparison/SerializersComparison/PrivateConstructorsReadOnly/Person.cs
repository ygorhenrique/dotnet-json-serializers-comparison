using System;
using System.Collections.Generic;

namespace Entities.PrivateConstructorsReadOnly
{
    public class Person
    {
        public string FirstName { get; }

        public string LastName { get; }

        public DateTime? DateOfBirth { get; }

        public IReadOnlyList<Person> Children { get; }

        private Person()
        {
        }
    }
}