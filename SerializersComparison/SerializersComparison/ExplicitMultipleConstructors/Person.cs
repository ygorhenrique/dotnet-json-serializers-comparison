using System;
using System.Collections.Generic;

namespace Entities.ExplicitMultipleConstructors
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public IReadOnlyList<Person> Children { get; set; }

        public Person(Person person)
        {
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
            this.DateOfBirth = person.DateOfBirth;
            this.Children = person.Children;
        }

        public Person(string firstName, string lastName, DateTime? dateOfBirth, IReadOnlyList<Person> children)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Children = children;
        }
    }
}