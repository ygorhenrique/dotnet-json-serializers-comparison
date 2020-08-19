using System;
using System.Collections.Generic;

namespace Entities.PrivateConstructorsReadOnly
{
    public struct PersonValue
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime? DateOfBirth { get; private set; }

        public IReadOnlyList<PersonValue> Children { get; private set; }

        // structs cannot have explicit parameterless constructors
        //public PersonValue()
        //{
        //}
    }
}