using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        ICarritoService CarritoService;

        public CarritoController(ICarritoService carritoService)
        {
            CarritoService = carritoService;
        }

        // GET: api/<CarritoController>
        [HttpGet]
        public IEnumerable<CarritoModel> Get()
        {
            return CarritoService.GetCarritos();
        }

        // GET api/<CarritoController>/5
        [HttpGet("{id}")]
        public CarritoModel Get(int id)
        {
            return CarritoService.GetById(id);
        }

        // POST api/<CarritoController>
        [HttpPost]
        public string Post([FromBody] CarritoModel Carrito)
        {
            var result = CarritoService.AddCarrito(Carrito);

            if (result)
            {
                return "Carrito Agregada Correctamente.";
            }
            return "Hubo un error al agregar  la entidad.";

        }

        // PUT api/<CarritoController>/5
        [HttpPut]
        public string Put([FromBody] CarritoModel Carrito)
        {
            var result = CarritoService.UpdateCarrito(Carrito);

            if (result)
            {
                return "Carrito Editada Correctamente.";
            }
            return "Hubo un error al editar  la entidad.";
        }

        // DELETE api/<CarritoController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            CarritoModel Carrito = new CarritoModel { IdCarrito = id };
            var result = CarritoService.DeteleCarrito(Carrito);

            if (result)
            {
                return "Carrito Eliminada Correctamente.";
            }
            return "Hubo un error al eliminar  la entidad.";

        }
    }
}
