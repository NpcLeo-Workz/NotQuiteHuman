using System.ComponentModel.DataAnnotations;

namespace NotQuiteHuman.ViewModels
{
    public class UserEditViewModel
    {       
        [Required]
        public string Email { get; set; }
        public string UserId { get; set; }
    }
}
