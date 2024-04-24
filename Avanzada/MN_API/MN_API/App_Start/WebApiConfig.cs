﻿using MN_API.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MN_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API
            config.MessageHandlers.Add(new TokenValidationHandler());

            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
