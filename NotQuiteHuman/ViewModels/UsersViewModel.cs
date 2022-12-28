using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
namespace NotQuiteHuman.ViewModels
{
    public class UsersViewModel
    {
        public List<IdentityUser> Users { get; set; }
    }
}
