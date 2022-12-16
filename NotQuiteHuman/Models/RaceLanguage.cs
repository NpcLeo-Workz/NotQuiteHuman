using System;
using System.ComponentModel.DataAnnotations;
namespace NotQuiteHuman.Models
{
    public class RaceLanguage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int RaceId { get; set; }
        [Required]
        public int LanguageId { get; set; }
        public Race Race { get; set; }
        public Language Language { get; set; }
    }
}
