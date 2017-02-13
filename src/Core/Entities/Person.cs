using System;

namespace Core.Entities
{
    public class Person
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public DateTime? Birthdate { get; set; }

        public DateTime? Deathdate { get; set; }

        public bool Sex { get; set; }
    }
}
