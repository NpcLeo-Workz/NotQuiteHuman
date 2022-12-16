using System;
using System.ComponentModel.DataAnnotations;
namespace NotQuiteHuman.Models
{
    public class Language
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Description { get; set; }
        
    }
}
