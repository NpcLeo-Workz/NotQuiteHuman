using System.ComponentModel.DataAnnotations;

namespace NotQuiteHuman.ViewModels
{
    public class CreateLanguageViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
