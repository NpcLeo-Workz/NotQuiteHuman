using System;
using System.ComponentModel.DataAnnotations;
namespace NotQuiteHuman.Models
{
    public class AbilityScoreBonus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Strength { get; set; }
        [Required]
        public int Dexterity { get; set; }
        [Required]
        public int Constitution { get; set; }
        [Required]
        public int Intelligence { get; set; }
        [Required]
        public int Wisdom { get; set; }
        [Required]
        public int Charisma { get; set; }
              
    }
}
