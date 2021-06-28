using CarComparisonProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarComparisonProject.Services
{
    public interface ICarComparison
    {
        List<CarModel> GetCarData();
        List<CarModel> NewestVehicle();
        List<CarModel> AlphabetizedList();
        List<CarModel> VehiclesByPrice();
        List<CarModel> BestValue();
        List<CarModel> RandomCar();
        IDictionary<int, decimal> MpgByYear();
        List<CarModel> FuelConsumption(int distance);
    }
}
