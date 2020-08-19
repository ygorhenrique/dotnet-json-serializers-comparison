using System;
using System.Collections.Generic;

namespace Entities.ExplicitConstructorsParameterless
{
    public struct PersonValue
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public IReadOnlyList<PersonValue> Children { get; set; }

        // structs cannot have explicit parameterless constructors
        //public PersonValue()
        //{
        //}
    }
}