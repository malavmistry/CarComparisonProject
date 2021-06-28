using CarComparisonProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarComparisonProject.Services
{
    public class CarComparison : ICarComparison
    {
        public CarComparison() { }
        public List<CarModel> GetCarData()
        {
            var carData = new List<CarModel>();
            carData.Add(new CarModel() {Make= "Honda", Model="CRV", Color="Green", Year=2016, Price= 23845, Rating= 8m, HwyMpg= 33m });
            carData.Add(new CarModel() {Make= "Ford", Model ="Escape", Color="Red", Year = 2017, Price = 23590, Rating = 7.8m, HwyMpg = 32m });
            carData.Add(new CarModel() {Make= "Hyundai", Model = "Sante Fe", Color = "Grey", Year = 2016, Price = 24950, Rating = 8m, HwyMpg = 27m });
            carData.Add(new CarModel() {Make= "Mazda", Model ="CX-5", Color = "Red", Year = 2017, Price = 21795, Rating = 8m, HwyMpg = 35m });
            carData.Add(new CarModel() {Make= "Subaru",Model = "Forester", Color = "Blue", Year=2016, Price = 22395,Rating= 8.4m, HwyMpg = 32m });
            return carData;
        }
        public List<CarModel> NewestVehicle()
        {
            var carData = GetCarData();
            return carData.OrderByDescending(x => x.Year).ThenBy(x => x.Model).ToList();
        }
        public List<CarModel> AlphabetizedList()
        {
            var carData = GetCarData();
            return carData.OrderBy(x => x.Model).ToList();
        }
        public List<CarModel> VehiclesByPrice()
        {
            var carData = GetCarData();
            return carData.OrderBy(x => x.Price).ThenBy(x => x.Model).ToList();
        }
        public List<CarModel> BestValue()
        {
            var carData = GetCarData().OrderByDescending(x=> (x.Rating*x.HwyMpg-(x.Price/100)));
            return carData.ToList();
        }
        public List<CarModel> FuelConsumption(int distance)
        {
            var carData = GetCarData();
            carData.ForEach(x => x.HwyMpg = Math.Round(distance / x.HwyMpg,2));
            return carData;
        }
        public List<CarModel> RandomCar()
        {
            var carData = GetCarData();
            Random rnd = new Random();
            return new List<CarModel>() { carData[rnd.Next(0, carData.Count())] };
        }
        public IDictionary<int, decimal> MpgByYear()
        {
            var carData = GetCarData();
            var result = (from car in carData
                         group car by car.Year into year
                         select new
                         {
                             Year = year.Key,
                             AvgMpg = Math.Round(year.Average(x => x.HwyMpg),2),
                         }).ToDictionary(key => key.Year, value=>value.AvgMpg);
            return result;
        }
    }
}
