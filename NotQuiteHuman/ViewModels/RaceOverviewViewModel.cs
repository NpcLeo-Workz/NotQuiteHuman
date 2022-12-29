using NotQuiteHuman.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NotQuiteHuman.ViewModels
{
    public class RaceOverviewViewModel
    {
        public List<Race> Races { get; set; }
        public List<AbilityScoreBonus> AbilityScoreBonuses { get; set; }
        public string RaceSearch { get; set; }
    }
}
