using System;
using System.Collections.Generic;

namespace Entities.ExplicitConstructors
{
    public struct PersonValue
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime? DateOfBirth { get; private set; }

        public IReadOnlyList<PersonValue> Children { get; private set; }

        public PersonValue(string firstName, string lastName, DateTime? dateOfBirth, IReadOnlyList<PersonValue> children)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Children = children;
        }
    }
}