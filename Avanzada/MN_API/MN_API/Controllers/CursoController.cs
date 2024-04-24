using MN_API.Entities;
using MN_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MN_API.Controllers
{
    [Authorize]
    public class CursoController : ApiController
    {

        [HttpGet]
        [Route("api/ConsultarCursos")]
        public List<CursoEnt> ConsultarCursos()
        {
            using (var bd = new GO_Proyecto())
            {
                var datos = (from x in bd.Curso
                             select x).ToList();

                List<CursoEnt> resp = new List<CursoEnt>();

                if (datos.Count > 0)
                {
                    foreach (var item in datos)
                    {
                        resp.Add(new CursoEnt
                        {
                            IdCurso = item.IdCurso,
                            Nombre = item.Nombre,
                            Descripcion = item.Descripcion,
                            Precio = item.Precio,
                            Instructor = item.Instructor,
                            Imagen = item.Imagen,
                            Video = item.Video
                        });
                    }
                }

                return resp;
            }
        }

        [HttpGet]
        [Route("api/ConsultarCurso")]
        public CursoEnt ConsultarCurso(long q)
        {
            using (var bd = new GO_Proyecto())
            {
                var datos = (from x in bd.Curso
                             where x.IdCurso == q
                             select x).FirstOrDefault();

                if (datos != null)
                {
                    CursoEnt resp = new CursoEnt();
                    resp.IdCurso = datos.IdCurso;
                    resp.Nombre = datos.Nombre;
                    resp.Descripcion = datos.Descripcion;
                    resp.Instructor = datos.Instructor;
                    resp.Precio = datos.Precio;
                    resp.Imagen = datos.Imagen;
                    resp.Video = datos.Video;
                    return resp;
                }

                return null;
            }
        }

        [HttpPost]
        [Route("api/RegistrarCurso")]
        public long RegistrarCurso(CursoEnt entidad)
        {
            using (var bd = new GO_Proyecto())
            {
                Curso tabla = new Curso();
                tabla.Nombre = entidad.Nombre;
                tabla.Descripcion = entidad.Descripcion;
                tabla.Instructor = entidad.Instructor;
                tabla.Precio = entidad.Precio;
                tabla.Imagen = entidad.Imagen;
                tabla.Video = entidad.Video;

                bd.Curso.Add(tabla);
                bd.SaveChanges();

                return tabla.IdCurso;
            }
        }

        [HttpPut]
        [Route("api/ActualizarRuta")]
        public void ActualizarRuta(CursoEnt entidad)
        {
            using (var bd = new GO_Proyecto())
            {
                var datos = (from x in bd.Curso
                             where x.IdCurso == entidad.IdCurso
                             select x).FirstOrDefault();

                if (datos != null)
                {
                    datos.Imagen = entidad.Imagen;
                    bd.SaveChanges();
                }
            }
        }

        [HttpPut]
        [Route("api/ActualizarCurso")]
        public int ActualizarCurso(CursoEnt entidad)
        {
            using (var bd = new GO_Proyecto())
            {
                var datos = (from x in bd.Curso
                             where x.IdCurso == entidad.IdCurso
                             select x).FirstOrDefault();

                if (datos != null)
                {
                    datos.Nombre = entidad.Nombre;
                    datos.Descripcion = entidad.Descripcion;
                    datos.Instructor = entidad.Instructor;
                    datos.Precio = entidad.Precio;
                    datos.Imagen = entidad.Imagen;
                    datos.Video = entidad.Video;
                    return bd.SaveChanges();
                }

                return 0;
            }
        }

    }
}
