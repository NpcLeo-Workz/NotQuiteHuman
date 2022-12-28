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
        public IActionResult Traits()
        {
            TraitsOverviewViewModel viewModel= new TraitsOverviewViewModel()
            {
                Traits = _context.Traits.ToList()
                
            };          
            return View(viewModel);

        }   
        public IActionResult CreateTrait() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTrait(CreateTraitViewModel viewModel)
        {
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
            Trait trait = await _context.Traits.FindAsync(id);
            _context.Traits.Remove(trait);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Traits));
        }
    }
}
