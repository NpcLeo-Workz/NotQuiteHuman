using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace NotQuiteHuman.ViewModels
{
    public class UserCreateViewModel
    {       
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public SelectList Roles { get; set; }
        public string RoleId { get; set; }
    }
}
