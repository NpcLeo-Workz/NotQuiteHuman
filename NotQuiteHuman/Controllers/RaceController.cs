using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotQuiteHuman.Data;
using NotQuiteHuman.Models;
using NotQuiteHuman.ViewModels;
using System.Collections.Generic;
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
        public IActionResult CreateRace()
        {
            return View();
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
                AbilityScoreBonus abilityScoreBonusCheck = _context.AbilityScoreBonus.Where(x => x.Equals(abilityScoreBonus)).FirstOrDefault();
                if (abilityScoreBonusCheck == null)
                {
                    _context.Add(abilityScoreBonusCheck);
                    await _context.SaveChangesAsync();
                }

                _context.Add(new Race()
                {
                    Name = viewModel.Name,
                    Size = viewModel.Size,
                    AbilityScoreBonusId = _context.AbilityScoreBonus.Where(x => x.Equals(abilityScoreBonus)).FirstOrDefault().Id,
                    WalkSpeed = viewModel.WalkSpeed,
                    SwimSpeed = viewModel.SwimSpeed,
                    ClimbSpeed = viewModel.ClimbSpeed,
                    FlySpeed = viewModel.FlySpeed,
                    CreatureType = viewModel.CreatureType
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }       
    }
}
