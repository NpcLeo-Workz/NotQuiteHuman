using System;
using System.ComponentModel.DataAnnotations;
namespace NotQuiteHuman.Models
{
    public class Race
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int AbilityScoreBonusId { get; set; }       
        public string Size { get; set; }
        public int WalkSpeed { get; set; }
        public int SwimSpeed { get; set; }
        public int FlySpeed { get; set; }
        public int ClimbSpeed { get; set; }
        [Required]
        public string CreatureType { get; set; }      


        public AbilityScoreBonus AbilityScoreBonus { get; set; }
    }
}
