using System.ComponentModel.DataAnnotations;

namespace NotQuiteHuman.ViewModels
{
    public class EditTraitViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
