using Microsoft.AspNetCore.Mvc.Rendering;
using NotQuiteHuman.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NotQuiteHuman.ViewModels
{
    public class DeleteRaceViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Size { get; set; }
        public int WalkSpeed { get; set; }
        public int SwimSpeed { get; set; }
        public int FlySpeed { get; set; }
        public int ClimbSpeed { get; set; }
        [Required]
        public string CreatureType { get; set; }
        public int Str { get; set; }
        public int Dex { get; set; }
        public int Con { get; set; }
        public int Int { get; set; }
        public int Wis { get; set; }
        public int Cha { get; set; }     
        public Language Language1 { get; set; }
        public Language Language2 { get; set; }
        public Language Language3 { get; set; }
        public Trait Trait1 { get; set; }
        public Trait Trait2 { get; set; }
        

    }
}
