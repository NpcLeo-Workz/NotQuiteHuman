using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotQuiteHuman.Data;
using NotQuiteHuman.Models;
using NotQuiteHuman.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NotQuiteHuman.Controllers
{
    public class RaceController : Controller
    {
        private readonly NotQuiteHumanContext _context;
        public RaceController(NotQuiteHumanContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            RaceOverviewViewModel viewModel = new RaceOverviewViewModel()
            {
                Races = _context.Races.ToList(),
                AbilityScoreBonuses = _context.AbilityScoreBonus.ToList()

            };
            return View(viewModel);
        }
        public IActionResult DeleteRace(int? id)
        {
            if (id == null) { return NotFound(); }
            Race race = _context.Races.Where(x => x.Id == id).Include(x => x.AbilityScoreBonus).FirstOrDefault();
            if (race == null) { return NotFound(); }
            DeleteRaceViewModel viewModel = new DeleteRaceViewModel()
            {               
                Language1 = _context.RaceLanguages.Where(x=>x.RaceId== race.Id).Include(x => x.Language).ToList()[0].Language,
                Language2 = _context.RaceLanguages.Where(x=>x.RaceId== race.Id).Include(x => x.Language).ToList()[1].Language,
                Language3 = _context.RaceLanguages.Where(x=>x.RaceId== race.Id).Include(x => x.Language).ToList()[2].Language,
                Trait1 = _context.RaceTraits.Where(x=>x.RaceId== race.Id).Include(x => x.Trait).ToList()[0].Trait,
                Trait2 = _context.RaceTraits.Where(x=>x.RaceId== race.Id).Include(x => x.Trait).ToList()[1].Trait,
                Id = race.Id,
                Name = race.Name,
                Size = race.Size,
                WalkSpeed = race.WalkSpeed,
                SwimSpeed = race.SwimSpeed,
                ClimbSpeed = race.ClimbSpeed,
                FlySpeed = race.FlySpeed,
                CreatureType = race.CreatureType,
                Str = race.AbilityScoreBonus.Strength,
                Dex = race.AbilityScoreBonus.Dexterity,
                Int = race.AbilityScoreBonus.Intelligence,
                Con = race.AbilityScoreBonus.Constitution,
                Wis = race.AbilityScoreBonus.Wisdom,
                Cha = race.AbilityScoreBonus.Charisma

            };
            return View(viewModel);
        }
        [HttpPost, ActionName("DeleteRace")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRaceConfirm(int id)
        {
            Race race = await _context.Races.FindAsync(id);
            foreach(var item in _context.RaceTraits.Where(_ => _.RaceId== race.Id))
            {
                _context.RaceTraits.Remove(item);
            }
            foreach(var item in _context.RaceLanguages.Where(_ => _.RaceId== race.Id))
            {
                _context.RaceLanguages.Remove(item);
            }
            _context.Races.Remove(race);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditRace(int? id)
        {
            if (id == null) { return NotFound(); }
            Race race = _context.Races.Where(x => x.Id == id).Include(x=>x.AbilityScoreBonus).FirstOrDefault();
            if (race == null) { return NotFound(); }
            EditRaceViewModel viewModel = new EditRaceViewModel()
            {
                Languages = new SelectList(_context.Languages.ToList(), "Id", "Name"),
                Traits = new SelectList(_context.Traits.ToList(), "Id", "Name"),
                Language1Id = _context.RaceLanguages.Where(x=>x.RaceId == id).ToList()[0].Id ,
                Language2Id = _context.RaceLanguages.Where(x => x.RaceId == id).ToList()[1].Id,
                Language3Id = _context.RaceLanguages.Where(x => x.RaceId == id).ToList()[2].Id,
                SelectedTrait1Id = _context.RaceTraits.Where(x=>x.RaceId == id).ToList()[0].Id,
                SelectedTrait2Id = _context.RaceTraits.Where(x=>x.RaceId == id).ToList()[1].Id,
                Id = race.Id,
                Name = race.Name,
                Size = race.Size,
                WalkSpeed = race.WalkSpeed,
                SwimSpeed = race.SwimSpeed,
                ClimbSpeed = race.ClimbSpeed,
                FlySpeed = race.FlySpeed,
                CreatureType = race.CreatureType,
                Str = race.AbilityScoreBonus.Strength,
                Dex = race.AbilityScoreBonus.Dexterity,
                Int = race.AbilityScoreBonus.Intelligence,
                Con = race.AbilityScoreBonus.Constitution,
                Wis = race.AbilityScoreBonus.Wisdom,
                Cha = race.AbilityScoreBonus.Charisma

            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRace(EditRaceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                AbilityScoreBonus abilityScoreBonus = new AbilityScoreBonus()
                {
                    Strength = viewModel.Str,
                    Dexterity = viewModel.Dex,
                    Constitution = viewModel.Con,
                    Intelligence = viewModel.Int,
                    Wisdom = viewModel.Wis,
                    Charisma = viewModel.Cha
                };
                AbilityScoreBonus abilityScoreBonusCheck = _context.AbilityScoreBonus.Where(c => c.Dexterity == abilityScoreBonus.Dexterity
                && c.Constitution == abilityScoreBonus.Constitution
                && c.Intelligence == abilityScoreBonus.Intelligence
                && c.Wisdom == abilityScoreBonus.Wisdom
                && c.Charisma == abilityScoreBonus.Charisma).FirstOrDefault();
                if (abilityScoreBonusCheck == null)
                {
                    _context.Add(abilityScoreBonus);
                    await _context.SaveChangesAsync();
                }
                
                    _context.Update(new Race()
                    {
                        Id= viewModel.Id,
                        Name = viewModel.Name,
                        Size = viewModel.Size,
                        AbilityScoreBonusId = _context.AbilityScoreBonus.Where(c => c.Dexterity == abilityScoreBonus.Dexterity
                            && c.Constitution == abilityScoreBonus.Constitution
                            && c.Intelligence == abilityScoreBonus.Intelligence
                            && c.Wisdom == abilityScoreBonus.Wisdom
                            && c.Charisma == abilityScoreBonus.Charisma).FirstOrDefault().Id,
                        WalkSpeed = viewModel.WalkSpeed,
                        SwimSpeed = viewModel.SwimSpeed,
                        ClimbSpeed = viewModel.ClimbSpeed,
                        FlySpeed = viewModel.FlySpeed,
                        CreatureType = viewModel.CreatureType
                    });
                    await _context.SaveChangesAsync();
                    //Check if exists not implemented

                    _context.Add(new RaceLanguage()
                    {
                        RaceId = viewModel.Id,
                        LanguageId = viewModel.Language1Id
                    });

                    _context.Add(new RaceLanguage()
                    {
                        RaceId = viewModel.Id,
                        LanguageId = viewModel.Language2Id
                    });
                    _context.Add(new RaceLanguage()
                    {
                        RaceId = viewModel.Id,
                        LanguageId = viewModel.Language3Id
                    });
                    _context.Add(new RaceTrait()
                    {
                        RaceId = viewModel.Id,
                        TraitId = viewModel.SelectedTrait1Id
                    });
                    _context.Add(new RaceTrait()
                    {
                        RaceId = viewModel.Id,
                        TraitId = viewModel.SelectedTrait2Id
                    });
                    await _context.SaveChangesAsync();
                


                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }
        public IActionResult CreateRace()
        {
            CreateRaceViewModel viewModel = new CreateRaceViewModel()
            {                              
                Languages = new SelectList( _context.Languages.ToList(), "Id", "Name"),
                Traits = new SelectList(_context.Traits.ToList(), "Id", "Name")
                
            };         
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRace(CreateRaceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                AbilityScoreBonus abilityScoreBonus = new AbilityScoreBonus()
                {
                    Strength = viewModel.Str,
                    Dexterity = viewModel.Dex,
                    Constitution = viewModel.Con,
                    Intelligence = viewModel.Int,
                    Wisdom = viewModel.Wis,
                    Charisma = viewModel.Cha
                };
                AbilityScoreBonus abilityScoreBonusCheck = _context.AbilityScoreBonus.Where(c => c.Dexterity == abilityScoreBonus.Dexterity 
                && c.Constitution == abilityScoreBonus.Constitution
                && c.Intelligence == abilityScoreBonus.Intelligence
                && c.Wisdom == abilityScoreBonus.Wisdom
                && c.Charisma == abilityScoreBonus.Charisma).FirstOrDefault();
                if (abilityScoreBonusCheck == null)
                {
                    _context.Add(abilityScoreBonus);
                    await _context.SaveChangesAsync();
                }
                if (_context.Races.Where(x=>x.Name == viewModel.Name).FirstOrDefault() == null)
                {
                     _context.Add(new Race()
                        {
                            Name = viewModel.Name,
                            Size = viewModel.Size,
                            AbilityScoreBonusId = _context.AbilityScoreBonus.Where(c => c.Dexterity == abilityScoreBonus.Dexterity
                                && c.Constitution == abilityScoreBonus.Constitution
                                && c.Intelligence == abilityScoreBonus.Intelligence
                                && c.Wisdom == abilityScoreBonus.Wisdom
                                && c.Charisma == abilityScoreBonus.Charisma).FirstOrDefault().Id,
                            WalkSpeed = viewModel.WalkSpeed,
                            SwimSpeed = viewModel.SwimSpeed,
                            ClimbSpeed = viewModel.ClimbSpeed,
                            FlySpeed = viewModel.FlySpeed,
                            CreatureType = viewModel.CreatureType
                        });
                    await _context.SaveChangesAsync();
                    //Check if exists not implemented
                    
                    _context.Add(new RaceLanguage()
                    {
                        RaceId = _context.Races.Where(x => x.Name == viewModel.Name).FirstOrDefault().Id,
                        LanguageId = viewModel.Language1Id
                    });
                    
                    _context.Add(new RaceLanguage()
                    {
                        RaceId = _context.Races.Where(x => x.Name == viewModel.Name).FirstOrDefault().Id,
                        LanguageId = viewModel.Language2Id
                    });
                    _context.Add(new RaceLanguage()
                    {
                        RaceId = _context.Races.Where(x => x.Name == viewModel.Name).FirstOrDefault().Id,
                        LanguageId = viewModel.Language3Id
                    });
                    _context.Add(new RaceTrait()
                    {
                        RaceId = _context.Races.Where(x => x.Name == viewModel.Name).FirstOrDefault().Id,
                        TraitId = viewModel.SelectedTrait1Id
                    });
                    _context.Add(new RaceTrait()
                    {
                        RaceId = _context.Races.Where(x => x.Name == viewModel.Name).FirstOrDefault().Id,
                        TraitId = viewModel.SelectedTrait2Id
                    });
                    await _context.SaveChangesAsync();
                }
               
                
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }
        public IActionResult RaceSearch(RaceOverviewViewModel vm)
        {
            if (!string.IsNullOrEmpty(vm.RaceSearch))
            {
                vm.Races = _context.Races.Where(x => x.Name.Contains(vm.RaceSearch)).ToList();
            }
            else
            {
                vm.Races = _context.Races.Include(x=>x.AbilityScoreBonus).ToList();
            }
            return View("Index", vm);
        }

    }
    
}
