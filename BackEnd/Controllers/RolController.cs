using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        IRolService RolService;

        public RolController(IRolService rolService)
        {
            RolService = rolService;
        }

        // GET: api/<RolController>
        [HttpGet]
        public IEnumerable<RolModel> Get()
        {
            return RolService.GetRols();
        }

        // GET api/<RolController>/5
        [HttpGet("{id}")]
        public RolModel Get(int id)
        {
            return RolService.GetById(id);
        }

        // POST api/<RolController>
        [HttpPost]
        public string Post([FromBody] RolModel Rol)
        {
            var result = RolService.AddRol(Rol);

            if (result)
            {
                return "Rol Agregada Correctamente.";
            }
            return "Hubo un error al agregar  la entidad.";

        }

        // PUT api/<RolController>/5
        [HttpPut]
        public string Put([FromBody] RolModel Rol)
        {
            var result = RolService.UpdateRol(Rol);

            if (result)
            {
                return "Rol Editada Correctamente.";
            }
            return "Hubo un error al editar  la entidad.";
        }

        // DELETE api/<RolController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            RolModel Rol = new RolModel { IdRol = id };
            var result = RolService.DeteleRol(Rol);

            if (result)
            {
                return "Rol Eliminada Correctamente.";
            }
            return "Hubo un error al eliminar  la entidad.";

        }
    }
}
