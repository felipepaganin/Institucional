using System;

namespace Brainz.Domain.Entities
{
    public class Person
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string InternalEmail { get; set; }
    }
}
