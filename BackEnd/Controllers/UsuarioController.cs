using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        IUsuarioService UsuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            UsuarioService = usuarioService;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<UsuarioModel> Get()
        {
            return UsuarioService.GetUsuarios();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public UsuarioModel Get(int id)
        {
            return UsuarioService.GetById(id);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public string Post([FromBody] UsuarioModel Usuario)
        {
            var result = UsuarioService.AddUsuario(Usuario);

            if (result)
            {
                return "Usuario Agregada Correctamente.";
            }
            return "Hubo un error al agregar  la entidad.";

        }

        // PUT api/<UsuarioController>/5
        [HttpPut]
        public string Put([FromBody] UsuarioModel Usuario)
        {
            var result = UsuarioService.UpdateUsuario(Usuario);

            if (result)
            {
                return "Usuario Editada Correctamente.";
            }
            return "Hubo un error al editar  la entidad.";
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            UsuarioModel Usuario = new UsuarioModel { IdUsuario = id };
            var result = UsuarioService.DeteleUsuario(Usuario);

            if (result)
            {
                return "Usuario Eliminada Correctamente.";
            }
            return "Hubo un error al eliminar  la entidad.";

        }
    }
}
