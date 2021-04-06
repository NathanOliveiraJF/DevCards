using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCards.API.InputModels
{
    public class AddCarInputModel
    {
        public AddCarInputModel(string brand, string model, string vinCode, int year, decimal price, string cor, DateTime productionDate)
        {
            Brand = brand;
            Model = model;
            VinCode = vinCode;
            Year = year;
            Price = price;
            Cor = cor;
            ProductionDate = productionDate;
        }

        //modelo de entrada

        public string Brand { get; set; }
        public string Model { get; set; }
        public string VinCode { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Cor { get; set; }
        public DateTime ProductionDate { get; set; }

    }
}
