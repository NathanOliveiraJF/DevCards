using DevCards.API.Entities;
using DevCards.API.InputModels;
using DevCards.API.Persistence;
using DevCards.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCards.API.Controllers
{
    [Route("api/constumers")]
    public class CustomersController : ControllerBase
    {
        private readonly DevCarsDbContext _dbContext;
        public CustomersController(DevCarsDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        //POST api/customers
        [HttpPost]
        public IActionResult Post([FromBody] AddCustomerInputModel model)
        {
            var customer = new Customer(4, model.FullName, model.Document, model.BirthDate);

            _dbContext.Customer.Add(customer);
            
            return NoContent();
        }

        //Post api/customers/2/orders
        [HttpPost("{id}/orders")]
        public IActionResult PostOrder(int id, [FromBody] AddOrderInputModel model)
        {
            //modela os items
            var extraItems = model.ExtraItems
                .Select(e => new ExtraOrderItem(e.Description, e.Price))
                .ToList();

            var car = _dbContext.Cars.SingleOrDefault(c => c.Id == model.IdCar);

            var order = new Order(1, model.IdCar, model.idCustomer, car.Price, extraItems);

            var customer = _dbContext.Customer.Single(car => car.Id == model.idCustomer);

            customer.Purchase(order);

            return CreatedAtAction(
                nameof(GetOrder), new { id = customer.Id, order = order.Id },
                model);
        }

        //Get api/customers/1/orders/3
        [HttpGet("{id}/orders/{orderid}")]
        public IActionResult GetOrder(int id, int orderid)
        {
            var customer = _dbContext.Customer.SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return NotFound();
            }

            var order = customer.Orders.SingleOrDefault(o => o.Id == orderid);
            var extraItems = order
                .ExtraItems.
                 Select(e => e.Description)
                .ToList();

            var orderViewModel = new OrderDetailsViewModel(order.IdCar, order.IdCustomer, order.TotalCost, extraItems);
            
            return Ok(orderViewModel);
        }
    }

}
