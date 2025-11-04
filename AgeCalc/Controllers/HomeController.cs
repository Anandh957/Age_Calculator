using AgeCalc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgeCalc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new AgeCalculatorModel());
        }

        [HttpPost]
        public IActionResult Calculate(AgeCalculatorModel model)
        {
            if (model.BirthDate.HasValue)
            {
                var today = DateTime.Today;
                var age = today - model.BirthDate.Value;
                var years = today.Year - model.BirthDate.Value.Year;
                var months = today.Month - model.BirthDate.Value.Month;
                var days = today.Day - model.BirthDate.Value.Day;

                if (months < 0 || (months == 0 && days < 0))
                {
                    years--;
                    months += 12;
                }

                if (days < 0)
                {
                    months--;
                    days += DateTime.DaysInMonth(today.Year, today.AddMonths(-1).Month);
                }

                model.Years = years;
                model.Months = months;
                model.Days = days;
            }

            return View("Index", model);
        }
    }
}
