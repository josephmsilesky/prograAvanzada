using MN_WEB.Entities;
using MN_WEB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MN_WEB.Controllers
{
    public class CursoController : Controller
    {
        CursoModel model = new CursoModel();

        [HttpGet]
        public ActionResult ConsultarMantCursos()
        {
            var datos = model.ConsultarCursos();
            return View(datos);
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AgregarCurso(CursoEnt entidad, HttpPostedFileBase imagenCurso)
        {
            entidad.Imagen = string.Empty;
            var idCurso = model.RegistrarCurso(entidad);

            string extensionImagen = Path.GetExtension(Path.GetFileName(imagenCurso.FileName));
            string rutaGuardarImagenes = AppDomain.CurrentDomain.BaseDirectory + "images\\" + idCurso + extensionImagen;
            imagenCurso.SaveAs(rutaGuardarImagenes);

            entidad.IdCurso = idCurso;
            entidad.Imagen = "\\images\\" + idCurso + extensionImagen;
            model.ActualizarRuta(entidad);

            return RedirectToAction("ConsultarMantCursos", "Curso");
        }

        [HttpGet]
        public ActionResult Editar(long q)
        {
            var datos = model.ConsultarCurso(q);
            return View(datos);
        }

        [HttpPost]
        public ActionResult EditarCurso(CursoEnt entidad, HttpPostedFileBase imagenCurso)
        {
            System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + entidad.Imagen);

            entidad.Imagen = string.Empty;
            model.ActualizarCurso(entidad);

            string extensionImagen = Path.GetExtension(Path.GetFileName(imagenCurso.FileName));
            string rutaGuardarImagenes = AppDomain.CurrentDomain.BaseDirectory + "images\\" + entidad.IdCurso + extensionImagen;
            imagenCurso.SaveAs(rutaGuardarImagenes);

            entidad.Imagen = "\\images\\" + entidad.IdCurso + extensionImagen;
            model.ActualizarRuta(entidad);

            return RedirectToAction("ConsultarMantCursos", "Curso");
        }

    }
}