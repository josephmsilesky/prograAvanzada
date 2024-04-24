﻿using MN_WEB.Entities;
using MN_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MN_WEB.Controllers
{
    public class CarritoController : Controller
    {
        CarritoModel model = new CarritoModel();
        CursoModel modelCursos = new CursoModel();

        [HttpGet]
        public ActionResult AgregarCursoCarrito(long q)
        {
            CarritoEnt entidad = new CarritoEnt();
            entidad.IdCurso = q;
            entidad.FechaRegistro = DateTime.Now;
            entidad.IdUsuario = long.Parse(Session["IdSesion"].ToString());

            var resp = model.AgregarCursoCarrito(entidad);

            var datos = model.ConsultarCarrito(long.Parse(Session["IdSesion"].ToString()));
            Session["Cantidad"] = datos.Count();
            Session["SubTotal"] = datos.Sum(x => x.Precio);
            Session["Total"] = datos.Sum(x => x.Precio) + (datos.Sum(x => x.Precio) * 0.13M);

            if (resp > 0)
            {
                return RedirectToAction("Principal", "Home");
            }
            else
            {
                var cursos = modelCursos.ConsultarCursos();
                ViewBag.MsjPantalla = "El curso ya fue comprado o agregado a su carrito de compras";
                return View("../Home/Principal", cursos);
            }
            
        }

        [HttpGet]
        public ActionResult RemoverCursoCarrito(long q)
        {
            var resp = model.RemoverCursoCarrito(q);

            var datos = model.ConsultarCarrito(long.Parse(Session["IdSesion"].ToString()));
            Session["Cantidad"] = datos.Count();
            Session["SubTotal"] = datos.Sum(x => x.Precio);
            Session["Total"] = datos.Sum(x => x.Precio) + (datos.Sum(x => x.Precio) * 0.13M);

            if (resp > 0)
            {
                return RedirectToAction("VerCarritoCompras", "Carrito");
            }
            else
            {
                ViewBag.MsjPantalla = "El curso no fue removido de su carrito de compras";
                return View("VerCarritoCompras");
            }
        }

        [HttpGet]
        public ActionResult VerCarritoCompras()
        {
            var datos = model.ConsultarCarrito(long.Parse(Session["IdSesion"].ToString()));
            return View(datos);
        }

        [HttpGet]
        public ActionResult ConsultarCompras()
        {
            var datos = model.ConsultarCompras(long.Parse(Session["IdSesion"].ToString()));
            return View(datos);
        }

        [HttpPost]
        public ActionResult ConfirmarPago()
        {
            CarritoEnt entidad = new CarritoEnt();
            entidad.IdUsuario = long.Parse(Session["IdSesion"].ToString());

            model.ConfirmarPago(entidad);
            return RedirectToAction("Principal", "Home");
        }

    }
}