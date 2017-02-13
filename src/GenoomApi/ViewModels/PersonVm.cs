using GenoomApi.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace GenoomApi.ViewModels
{
    public class PersonVm
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public DateTime? Birthdate { get; set; }

        public DateTime? Deathdate { get; set; }

        [Required]
        public Sex Sex { get; set; }
    }
}
