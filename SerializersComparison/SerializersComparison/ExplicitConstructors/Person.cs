using System;
using System.Collections.Generic;

namespace Entities.ExplicitConstructors
{
    public class Person
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime? DateOfBirth { get; private set; }

        public IReadOnlyList<Person> Children { get; private set; }

        public Person(string firstName, string lastName, DateTime? dateOfBirth, IReadOnlyList<Person> children)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Children = children;
        }
    }
}