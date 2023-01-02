using Microsoft.AspNetCore.Mvc.Rendering;
using NotQuiteHuman.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NotQuiteHuman.ViewModels
{
    public class EditRaceViewModel
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
        public SelectList Languages { get; set; }
        public int Language1Id { get; set; }
        public int Language2Id { get; set; }
        public int Language3Id { get; set; }
        public int SelectedTrait1Id { get; set; }
        public int SelectedTrait2Id { get; set; }
        public SelectList Traits { get; set; }

    }
}
