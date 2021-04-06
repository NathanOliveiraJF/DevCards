using DevCards.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCards.API.Persistence
{
    public class DevCarsDbContext
    {
        public DevCarsDbContext()
        {

        }
        public List<Car> Cars { get; set; }
        public List<Customer> Customer { get; set; }
    }
}
