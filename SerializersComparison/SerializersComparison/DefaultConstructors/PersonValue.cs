using System;
using System.Collections.Generic;

namespace Entities.DefaultConstructors
{
    public struct PersonValue
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public IReadOnlyList<PersonValue> Children { get; set; }
    }
}