﻿using MN_API.Entities;
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
    public class BitacoraController : ApiController
    {

        [HttpPost]
        [Route("api/RegistrarBitacora")]
        public void RegistrarBitacora(BitacoraEnt entidad)
        {
            using (var bd = new GO_Proyecto())
            {
                bd.RegistrarBitacora(entidad.Origen, entidad.Mensaje, entidad.IdUsuario);
            }
        }

    }
}
