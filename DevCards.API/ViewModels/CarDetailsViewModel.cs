using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCards.API.ViewModels
{
    public class CarDetailsViewModel
    {
        public CarDetailsViewModel(int id, string brand, string model, string vinCode, int year, decimal price, string cor, DateTime productionDate)
        {
            Id = id;
            Brand = brand;
            Model = model;
            VinCode = vinCode;
            Year = year;
            Price = price;
            Cor = cor;
            ProductionDate = productionDate;
        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string VinCode { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Cor { get; set; }
        public DateTime ProductionDate { get; set; }
    }
}
