using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCards.API.Entities
{
    public class Customer
    {
        public Customer(int id, string fullNome, string document, DateTime birthDate)
        {
            Id = id;
            FullNome = fullNome;
            Document = document;
            BirthDate = birthDate;
            Orders = new List<Order>();
        }

        public int Id { get; private set; }
        public string FullNome { get; private set; }
        public string Document { get; private set; }
        public DateTime BirthDate { get; private set; }
        public List<Order> Orders { get; private set; }

        public void Purchase(Order order)
        {
            Orders.Add(order);
        }
    }
}
