using MN_API.Entities;
using MN_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace MN_API.Controllers
{
    [Authorize]
    public class CarritoController : ApiController
    {

        [HttpPost]
        [Route("api/AgregarCursoCarrito")]
        public int AgregarCursoCarrito(CarritoEnt entidad)
        {
            using (var bd = new GO_Proyecto())
            {
                var existeEnCarrito = (from x in bd.Carrito
                                       where x.IdUsuario == entidad.IdUsuario
                                          && x.IdCurso == entidad.IdCurso
                                       select x).ToList();

                var existeEnCompras = (from x in bd.Compra
                                       where x.IdUsuario == entidad.IdUsuario
                                          && x.IdCurso == entidad.IdCurso
                                       select x).ToList();

                if (existeEnCarrito.Count > 0 || existeEnCompras.Count > 0)
                {
                    return 0;
                }

                Carrito tabla = new Carrito();
                tabla.IdUsuario = entidad.IdUsuario;
                tabla.IdCurso = entidad.IdCurso;
                tabla.FechaRegistro = entidad.FechaRegistro;

                bd.Carrito.Add(tabla);
                return bd.SaveChanges();
            }
        }

        [HttpDelete]
        [Route("api/RemoverCursoCarrito")]
        public int RemoverCursoCarrito(long q)
        {
            using (var bd = new GO_Proyecto())
            {
                var curso = (from x in bd.Carrito
                             where x.IdCarrito == q
                             select x).FirstOrDefault();

                if (curso != null)
                {
                    bd.Carrito.Remove(curso);
                    return bd.SaveChanges();
                }

                return 0;
            }
        }

        [HttpGet]
        [Route("api/ConsultarCarrito")]
        public List<CarritoEnt> ConsultarCarrito(long q)
        {
            using (var bd = new GO_Proyecto())
            {
                var datos = (from x in bd.Carrito
                             join r in bd.Curso on x.IdCurso equals r.IdCurso
                             where x.IdUsuario == q
                             select new
                             {
                                 x.IdCarrito,
                                 x.IdUsuario,
                                 x.IdCurso,
                                 x.FechaRegistro,
                                 r.Precio,
                                 r.Nombre,
                                 r.Instructor
                             }).ToList();

                List<CarritoEnt> resp = new List<CarritoEnt>();

                if (datos.Count > 0)
                {
                    foreach (var item in datos)
                    {
                        resp.Add(new CarritoEnt
                        {
                            IdCarrito = item.IdCarrito,
                            IdUsuario = item.IdUsuario,
                            IdCurso = item.IdCurso,
                            FechaRegistro = item.FechaRegistro,
                            Precio = item.Precio,
                            Nombre = item.Nombre,
                            Instructor = item.Instructor,
                            Impuesto = item.Precio * 0.13M
                        });
                    }
                }

                return resp;
            }
        }

        [HttpGet]
        [Route("api/ConsultarCompras")]
        public List<CarritoEnt> ConsultarCompras(long q)
        {
            using (var bd = new GO_Proyecto())
            {
                var datos = (from x in bd.Compra
                             join r in bd.Curso on x.IdCurso equals r.IdCurso
                             where x.IdUsuario == q
                             select new
                             {
                                 x.IdCompra,
                                 x.IdUsuario,
                                 x.IdCurso,
                                 x.FechaCompra,
                                 x.PrecioPagado,
                                 r.Nombre,
                                 r.Instructor
                             }).ToList();

                List<CarritoEnt> resp = new List<CarritoEnt>();

                if (datos.Count > 0)
                {
                    foreach (var item in datos)
                    {
                        resp.Add(new CarritoEnt
                        {
                            IdCompra = item.IdCompra,
                            IdUsuario = item.IdUsuario,
                            IdCurso = item.IdCurso,
                            FechaCompra = item.FechaCompra,
                            PrecioPagado = item.PrecioPagado,
                            Nombre = item.Nombre,
                            Instructor = item.Instructor,
                            Impuesto = item.PrecioPagado * 0.13M
                        });
                    }
                }

                return resp;
            }
        }

        [HttpPost]
        [Route("api/ConfirmarPago")]
        public int ConfirmarPago(CarritoEnt entidad)
        {
            using (var bd = new GO_Proyecto())
            {
                //Tomar los productos del carrito para meterlos en la tabla de compras
                var datos = (from x in bd.Carrito
                             join y in bd.Curso on x.IdCurso equals y.IdCurso
                             where x.IdUsuario == entidad.IdUsuario
                             select new { 
                                x.IdCurso,
                                x.IdUsuario,
                                y.Precio
                             }).ToList();

                if(datos.Count > 0)
                {
                    foreach (var item in datos)
                    {
                        Compra comp = new Compra();
                        comp.IdCurso = item.IdCurso;
                        comp.IdUsuario = item.IdUsuario;
                        comp.FechaCompra = DateTime.Now;
                        comp.PrecioPagado = item.Precio;
                        bd.Compra.Add(comp);
                    }

                    //Tomar los productos del carrito para borrarlos
                    var carrito = (from x in bd.Carrito
                                 where x.IdUsuario == entidad.IdUsuario
                                 select x).ToList();

                    if (carrito.Count > 0)
                    {
                        foreach (var item in carrito)
                        {
                            bd.Carrito.Remove(item);
                        }
                    }

                    return bd.SaveChanges();
                }

                return 0;
            }
        }

    }
}
