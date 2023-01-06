using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotQuiteHuman.Data;
using NotQuiteHuman.Models;
using NotQuiteHuman.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NotQuiteHuman.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly NotQuiteHumanContext _context;
        public AdminController(NotQuiteHumanContext context)
        {
            _context = context;
        }

        public IActionResult Users()
        {
            return View();
        }
        #region Traits
        public IActionResult Traits()
        {
            //Traits overview page
            TraitsOverviewViewModel viewModel= new TraitsOverviewViewModel()
            {
                Traits = _context.Traits.ToList()
                
            };          
            return View(viewModel);

        }   
        public IActionResult CreateTrait() 
        {
            //Create Trait page
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTrait(CreateTraitViewModel viewModel)
        {
            //Create trait action
            if (ModelState.IsValid)
            {
                _context.Add(new Trait()
                {
                    Name= viewModel.Name,
                    Description= viewModel.Description
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Traits));
            }
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult EditTrait(int? id)
        {
            //Edit trait page only works with valid Id
            if (id == null) { return NotFound(); }
            Trait trait = _context.Traits.Where(x => x.Id == id).FirstOrDefault();
            Debug.WriteLine(trait);
            if (trait == null) { return NotFound(); }
            EditTraitViewModel viewModel = new EditTraitViewModel()
            {
                Id = trait.Id,
                Name = trait.Name,
                Description = trait.Description
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTrait(int id, EditTraitViewModel viewModel)
        {
            //Edit trait action Edits only if found
            if(id != viewModel.Id){ return NotFound();}
            if (ModelState.IsValid)
            {

                try
                {
                    Trait trait = new Trait()
                    {
                        Id= viewModel.Id,
                        Name= viewModel.Name,
                        Description= viewModel.Description
                    };
                    _context.Update(trait);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException exception)
                {
                    if (!_context.Traits.Any(x => x.Id == viewModel.Id))
                    {
                        return NotFound();
                    }
                    else { throw; }
                }
                return RedirectToAction(nameof(Traits));
            }
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult DeleteTrait(int id)
        {
            //Delete page only works if trait exists
            Trait trait = _context.Traits.Where(x=>x.Id == id).FirstOrDefault();
            if (trait != null)
            {
                DeleteTraitViewModel viewModel= new DeleteTraitViewModel()
                {
                    Id=trait.Id,
                    Name=trait.Name,
                    Description=trait.Description

                };
                return View(viewModel);

            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost, ActionName("DeleteTrait")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTraitConfirm(int id)
        {
            //Delete action
            Trait trait = await _context.Traits.FindAsync(id);
            _context.Traits.Remove(trait);
            await _context.SaveChangesAsync();
         
            return RedirectToAction(nameof(Traits));
        }
        
        public IActionResult TraitSearch(TraitsOverviewViewModel vm)
        {
            //search filter for traits
            if (!string.IsNullOrEmpty(vm.TraitSearch))
            {
                vm.Traits = _context.Traits.Where(x => x.Name.Contains(vm.TraitSearch) || x.Description.Contains(vm.TraitSearch)).ToList();
            }
            else
            {
                vm.Traits = _context.Traits.ToList();
            }
            return View("Traits", vm);
        }
        #endregion
        #region Languages
        public IActionResult Languages()
        {
            //Languages Page
            LanguageOverViewViewModel viewModel = new LanguageOverViewViewModel()
            {
                Languages = _context.Languages.ToList()

            };
            return View(viewModel);

        }
        public IActionResult CreateLanguage()
        {
            //Create language page
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLanguage(CreateLanguageViewModel viewModel)
        {
            //Create Language Action
            if (ModelState.IsValid)
            {
                _context.Add(new Language()
                {
                    Name = viewModel.Name,
                    Type = viewModel.Type,
                    Description = viewModel.Description
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Languages));
            }
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult EditLanguage(int? id)
        {
            //Edit language page only works if valid Id
            if (id == null) { return NotFound(); }
            Language language = _context.Languages.Where(x => x.Id == id).FirstOrDefault();           
            if (language == null) { return NotFound(); }
            EditLanguageViewModel viewModel = new EditLanguageViewModel()
            {
                Id = language.Id,
                Name = language.Name,
                Type = language.Type,
                Description = language.Description
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLanguage(int id, EditLanguageViewModel viewModel)
        {
            //Edit language Action
            if (id != viewModel.Id) { return NotFound(); }
            if (ModelState.IsValid)
            {

                try
                {
                    Language language = new Language()
                    {
                        Id = viewModel.Id,
                        Name = viewModel.Name,
                        Type = viewModel.Type,
                        Description = viewModel.Description
                    };
                    _context.Update(language);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException exception)
                {
                    if (!_context.Traits.Any(x => x.Id == viewModel.Id))
                    {
                        return NotFound();
                    }
                    else { throw; }
                }
                return RedirectToAction(nameof(Languages));
            }
            return View(viewModel);
        }
        public IActionResult DeleteLanguage(int id)
        {
            //Delete language page
            Language language = _context.Languages.Where(x => x.Id == id).FirstOrDefault();
            if (language != null)
            {
                DeleteLanguageViewModel viewModel = new DeleteLanguageViewModel()
                {
                    Id = language.Id,
                    Name = language.Name,
                    Type= language.Type,
                    Description = language.Description

                };
                return View(viewModel);

            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost, ActionName("DeleteLanguage")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteLanguageConfirm(int id)
        {
            //Delete Language Action
            Language language = await _context.Languages.FindAsync(id);
            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Languages));
        }
        public IActionResult LanguageSearch(LanguageOverViewViewModel vm)
        {
            //Search for Languages
            if (!string.IsNullOrEmpty(vm.LanguageSearch))
            {
                vm.Languages = _context.Languages.Where(x => x.Name.Contains(vm.LanguageSearch) || x.Description.Contains(vm.LanguageSearch) || x.Type.Contains(vm.LanguageSearch)).ToList();
            }
            else
            {
                vm.Languages = _context.Languages.ToList();
            }
            return View("Languages", vm);
        }
        #endregion       
    }
}