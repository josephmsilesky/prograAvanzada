using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        ICategoriaService CategoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            CategoriaService = categoriaService;
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public IEnumerable<CategoriaModel> Get()
        {
            return CategoriaService.GetCategorias();
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public CategoriaModel Get(int id)
        {
            return CategoriaService.GetById(id);
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public string Post([FromBody] CategoriaModel Categoria)
        {
            var result = CategoriaService.AddCategoria(Categoria);

            if (result)
            {
                return "Categoria Agregada Correctamente.";
            }
            return "Hubo un error al agregar  la entidad.";

        }

        // PUT api/<CategoriaController>/5
        [HttpPut]
        public string Put([FromBody] CategoriaModel Categoria)
        {
            var result = CategoriaService.UpdateCategoria(Categoria);

            if (result)
            {
                return "Categoria Editada Correctamente.";
            }
            return "Hubo un error al editar  la entidad.";
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            CategoriaModel Categoria = new CategoriaModel { IdCategoria = id };
            var result = CategoriaService.DeteleCategoria(Categoria);

            if (result)
            {
                return "Categoria Eliminada Correctamente.";
            }
            return "Hubo un error al eliminar  la entidad.";

        }
    }
}
