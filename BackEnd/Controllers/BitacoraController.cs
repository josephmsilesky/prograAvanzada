using BackEnd.Models;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitacoraController : ControllerBase
    {
        IBitacoraService BitacoraService;

        public BitacoraController(IBitacoraService bitacoraService)
        {
            BitacoraService = bitacoraService;
        }

        // GET: api/<BitacoraController>
        [HttpGet]
        public IEnumerable<BitacoraModel> Get()
        {
            return BitacoraService.GetBitacoras();
        }

        // GET api/<BitacoraController>/5
        [HttpGet("{id}")]
        public BitacoraModel Get(int id)
        {
            return BitacoraService.GetById(id);
        }

        // POST api/<BitacoraController>
        [HttpPost]
        public string Post([FromBody] BitacoraModel Bitacora)
        {
            var result = BitacoraService.AddBitacora(Bitacora);

            if (result)
            {
                return "Bitacora Agregada Correctamente.";
            }
            return "Hubo un error al agregar  la entidad.";

        }

        // PUT api/<BitacoraController>/5
        [HttpPut]
        public string Put([FromBody] BitacoraModel Bitacora)
        {
            var result = BitacoraService.UpdateBitacora(Bitacora);

            if (result)
            {
                return "Bitacora Editada Correctamente.";
            }
            return "Hubo un error al editar  la entidad.";
        }

        // DELETE api/<BitacoraController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            BitacoraModel Bitacora = new BitacoraModel { IdBitacora = id };
            var result = BitacoraService.DeteleBitacora(Bitacora);

            if (result)
            {
                return "Bitacora Eliminada Correctamente.";
            }
            return "Hubo un error al eliminar  la entidad.";

        }
    }
}
