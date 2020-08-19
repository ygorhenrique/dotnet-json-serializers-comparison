using System;
using System.Collections.Generic;

namespace Entities.ExplicitMultipleConstructors
{
    public struct PersonValue
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public IReadOnlyList<PersonValue> Children { get; set; }

        public PersonValue(PersonValue person)
        {
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
            this.DateOfBirth = person.DateOfBirth;
            this.Children = person.Children;
        }

        public PersonValue(string firstName, string lastName, DateTime? dateOfBirth, IReadOnlyList<PersonValue> children)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Children = children;
        }
    }
}