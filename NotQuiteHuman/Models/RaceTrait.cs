using System;
using System.ComponentModel.DataAnnotations;
namespace NotQuiteHuman.Models
{
    public class RaceTrait
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int RaceId { get; set; }
        [Required]
        public int TraitId { get; set; }
        public Race Race { get; set; }
        public Trait Trait { get; set; }
    }
}
