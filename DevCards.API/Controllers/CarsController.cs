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
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {

        private readonly DevCarsDbContext _dbContext;
        public CarsController(DevCarsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {

            //retorna lista de carItemViewModel(dto)
            var cars = _dbContext.Cars;
            //projecao de dados: retorna apenas o quer para front

            var carsViewModel = cars.
                Select(c => new CarItemViewModel(c.Id, c.Brand, c.Model, c.Price))
                .ToList();

            return Ok(carsViewModel);
        }

        //api/cars/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Se carro de indentificador não existir, retorna notfound
            // senao ok

            //singleOrDefault -> busca unico elemento igual id
            var car = _dbContext.Cars.SingleOrDefault(c => c.Id == id);

            if(car == null)
            {
                return NotFound();
            }

            var carDetailsViewModel = new CarDetailsViewModel(
                car.Id,
                car.Brand,
                car.Model,
                car.VinCode,
                car.Year,
                car.Price,
                car.Color,
                car.ProductionDate
                );
            return Ok(carDetailsViewModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddCarInputModel model)
        {
            //Frombody --> dados do corpo
            // se o cadastro funcionar, retorna created (201)
            //se os dados de entrada estiverem incorretos, retorna badrequest(400)
            //se o cadastro funcionar, mas nao tiver uma api de consulta, retorna NoContent(204)
            
            var car = new Car(4, model.VinCode, model.Brand, model.Model, model.Year, model.Price, model.Cor, model.ProductionDate);
            _dbContext.Cars.Add(car);

            //primeiro paramentro: nome da acao que vai consultar
            //segundo paramentro: objeto anonimo com parametro
            //terceiro a modelagem

            return CreatedAtAction(
               nameof(GetById),
               new { id = car.Id },
               model
               );
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCarInputModel model)
        {
            //se a atualizacao funcionar, retorna 204 No content
            //se os dados de entrada estiverem incorretos, retorna 400 badrequest
            //se nao existir retorna not found 404

            var car = _dbContext.Cars.SingleOrDefault(car => car.Id == id);

            if(car == null)
            {
                return NotFound();
            }
            //utiliza dto apenas para salvar os dados que devem ser modifcados
            car.Update(model.Color, model.Price);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //se nao existir, retorna notfound 404
            //se for com sucesso, retorna no content 204
            var car = _dbContext.Cars.SingleOrDefault(car => car.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            car.SetAsSuspended();

            return NoContent();
        }
    }
}
