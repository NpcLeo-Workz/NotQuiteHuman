using NotQuiteHuman.Areas.Identity;
using NotQuiteHuman.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace NotQuiteHuman.Controllers
{
    public class UserController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public UserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) 
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            // User overview page
            UsersViewModel viewModel = new UsersViewModel()
            {
                Users = _userManager.Users.ToList()
            };
            return View(viewModel);
        }
        public IActionResult Edit(string id)
        {
            //Edit user Page
            IdentityUser user = _userManager.Users.Where(k => k.Id == id).FirstOrDefault();


            if (user != null)
            {
                UserEditViewModel viewModel = new UserEditViewModel()
                {
                    UserId = user.Id,                              
                    Email = user.UserName,                   

                };
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserEditViewModel viewModel)
        {
            //Edit User Action
            if (ModelState.IsValid) 
            { 
                IdentityUser user = await _userManager.FindByIdAsync(viewModel.UserId);
                user.UserName = viewModel.Email;
                user.Email = viewModel.Email;

                IdentityResult result = await _userManager.UpdateAsync(user);
                if (result.Succeeded) { return RedirectToAction("Index"); }
                else { foreach(IdentityError error in result.Errors) { ModelState.AddModelError("", error.Description); } }
            }
            return View(viewModel);
        }
        public IActionResult Create()
        {
            //Create user page
            UserCreateViewModel viewModel= new UserCreateViewModel()
            {
                Roles = new SelectList(_roleManager.Roles.ToList(), "Id", "Name")
            };
            return View(viewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateViewModel viewModel)
        {
            // Create User action
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser()
                {
                    UserName = viewModel.Email,                   
                    Email = viewModel.Email
                };
                IdentityResult result = await _userManager.CreateAsync(user, viewModel.Password);
                if (result.Succeeded) 
                {
                    IdentityUser user1 = await _userManager.FindByEmailAsync(viewModel.Email);
                    IdentityRole role = await _roleManager.FindByIdAsync(viewModel.RoleId);
                    IdentityResult result1 = await _userManager.AddToRoleAsync(user1, role.Name);
                    return RedirectToAction("Index"); 
                }
                else { foreach (IdentityError error in result.Errors) { ModelState.AddModelError("", error.Description); } }           
            }
            return View(viewModel);
        }
        public async Task<IActionResult> Delete(string id)
        {
            //Delete user page
            IdentityUser user = await _userManager.FindByIdAsync(id); if (user == null) { return NotFound(); }
            UserDeleteViewModel viewModel = new UserDeleteViewModel()
            {
                UserName = user.UserName,
                UserId = id
            };
            return View(viewModel);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            // Delete User Action
            IdentityUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            { 
                IdentityResult result = await _userManager.DeleteAsync(user);
                if(result.Succeeded) { return RedirectToAction("Index"); } else { foreach (IdentityError error in result.Errors) { ModelState.AddModelError("", error.Description); } }

            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View("Index", _userManager.Users.ToList());
        }       
    }
}
