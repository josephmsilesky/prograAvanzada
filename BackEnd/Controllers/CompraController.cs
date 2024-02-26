using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        ICompraService CompraService;

        public CompraController(ICompraService compraService)
        {
            CompraService = compraService;
        }

        // GET: api/<CompraController>
        [HttpGet]
        public IEnumerable<CompraModel> Get()
        {
            return CompraService.GetCompras();
        }

        // GET api/<CompraController>/5
        [HttpGet("{id}")]
        public CompraModel Get(int id)
        {
            return CompraService.GetById(id);
        }

        // POST api/<CompraController>
        [HttpPost]
        public string Post([FromBody] CompraModel Compra)
        {
            var result = CompraService.AddCompra(Compra);

            if (result)
            {
                return "Compra Agregada Correctamente.";
            }
            return "Hubo un error al agregar  la entidad.";

        }

        // PUT api/<CompraController>/5
        [HttpPut]
        public string Put([FromBody] CompraModel Compra)
        {
            var result = CompraService.UpdateCompra(Compra);

            if (result)
            {
                return "Compra Editada Correctamente.";
            }
            return "Hubo un error al editar  la entidad.";
        }

        // DELETE api/<CompraController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            CompraModel Compra = new CompraModel { IdCompra = id };
            var result = CompraService.DeteleCompra(Compra);

            if (result)
            {
                return "Compra Eliminada Correctamente.";
            }
            return "Hubo un error al eliminar  la entidad.";

        }
    }
}
