using CarComparisonProject.Models;
using CarComparisonProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarComparisonProject.Controllers
{
    public class CarComparisonController : Controller
    {
        private readonly ILogger<CarComparisonController> _logger;
        private readonly ICarComparison _carComparison;

        public CarComparisonController(ILogger<CarComparisonController> logger, ICarComparison carComparison)
        {
            _logger = logger;
            _carComparison = carComparison;
        }

        public IActionResult Index()
        {
            var model = _carComparison.GetCarData();
            return View(model);
        }

        public IActionResult GetResults(int selectedOption)
        {
            switch (selectedOption)
            {
                case 1: return PartialView("_CarTable", _carComparison.NewestVehicle());
                case 2: return PartialView("_CarTable", _carComparison.AlphabetizedList());
                case 3: return PartialView("_CarTable", _carComparison.VehiclesByPrice());
                case 4: return PartialView("_CarTable", _carComparison.BestValue());
                case 6: return PartialView("_CarTable", _carComparison.RandomCar());
                case 7: return PartialView("_AvgMpg", _carComparison.MpgByYear());
            }
            return PartialView("_CarTable", _carComparison.GetCarData());
        }

        public IActionResult GetFuelConsumption(int distance)
        {
            return PartialView("_FuelConsumption", _carComparison.FuelConsumption(distance));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
