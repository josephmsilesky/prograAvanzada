using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        ICursoService CursoService;

        public CursoController(ICursoService cursoService)
        {
            CursoService = cursoService;
        }

        // GET: api/<CursoController>
        [HttpGet]
        public IEnumerable<CursoModel> Get()
        {
            return CursoService.GetCursos();
        }

        // GET api/<CursoController>/5
        [HttpGet("{id}")]
        public CursoModel Get(int id)
        {
            return CursoService.GetById(id);
        }

        // POST api/<CursoController>
        [HttpPost]
        public string Post([FromBody] CursoModel Curso)
        {
            var result = CursoService.AddCurso(Curso);

            if (result)
            {
                return "Curso Agregada Correctamente.";
            }
            return "Hubo un error al agregar  la entidad.";

        }

        // PUT api/<CursoController>/5
        [HttpPut]
        public string Put([FromBody] CursoModel Curso)
        {
            var result = CursoService.UpdateCurso(Curso);

            if (result)
            {
                return "Curso Editada Correctamente.";
            }
            return "Hubo un error al editar  la entidad.";
        }

        // DELETE api/<CursoController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            CursoModel Curso = new CursoModel { IdCurso = id };
            var result = CursoService.DeteleCurso(Curso);

            if (result)
            {
                return "Curso Eliminada Correctamente.";
            }
            return "Hubo un error al eliminar  la entidad.";

        }
    }
}
