using GenoomApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace GenoomApi.ViewModels
{
    public class FamilyVm
    {
        public int Id { get; set; }

        [Required]
        public int SourcePersonId { get; set; }

        public PersonVm SourcePerson { get; set; }

        [Required]
        public int TargetPersonId { get; set; }

        public PersonVm TargetPerson { get; set; }

        [Required]
        public Relation Relation { get; set; }

    }
}
