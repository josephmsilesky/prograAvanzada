﻿using MN_WEB.Entities;
using MN_WEB.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MN_WEB.Controllers
{
    public class HomeController : Controller
    {
        UsuarioModel model = new UsuarioModel();
        CursoModel modelCursos = new CursoModel();
        CarritoModel modelCarrito = new CarritoModel();


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(UsuarioEnt entidad)
        {
            try
            {
                var resp = model.IniciarSesion(entidad);

                if (resp != null)
                {
                    Session["IdSesion"] = resp.IdUsuario.ToString();
                    Session["CorreoSesion"] = resp.CorreoElectronico;
                    Session["NombreSesion"] = resp.Nombre;
                    Session["RolSesion"] = resp.NombreRol;
                    Session["IdRolSesion"] = resp.IdRol;
                    Session["TokenSesion"] = resp.Token;

                    return RedirectToAction("Principal", "Home");
                }
                else
                {
                    ViewBag.MsjPantalla = "No se ha podido validar su información";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.MsjPantalla = "Consulta con el administrador del sistema";
                return View("Index");
            }
        }



        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrarse(UsuarioEnt entidad)
        {
            entidad.IdRol = 2;
            entidad.Estado = true;

            var resp = model.Registrarse(entidad);

            if (resp > 0)
                return RedirectToAction("Index", "Home");
            else
            {
                ViewBag.MsjPantalla = "No se ha podido registrar su información";
                return View("Registro");
            }
        }



        [HttpGet]
        public ActionResult Recuperar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecuperarContrasenna(UsuarioEnt entidad)
        {
            var resp = model.RecuperarContrasenna(entidad);

            if (resp)
                return RedirectToAction("Index", "Home");
            else
            {
                ViewBag.MsjPantalla = "No se ha podido recuperar su información";
                return View("Recuperar");
            }
        }



        [HttpGet]
        public ActionResult Principal()
        {
            var datos = modelCarrito.ConsultarCarrito(long.Parse(Session["IdSesion"].ToString()));
            Session["Cantidad"] = datos.Count();
            Session["SubTotal"] = datos.Sum(x => x.Precio);
            Session["Total"] = datos.Sum(x => x.Precio) + (datos.Sum(x => x.Precio) * 0.13M);

            var cursos = modelCursos.ConsultarCursos();
            return View(cursos);
        }


    }
}