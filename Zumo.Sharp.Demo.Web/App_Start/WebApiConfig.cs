﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Zumo.Sharp.AspNet.Handlers;

namespace ZumoSharp.Demo.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {


            var cors = new EnableCorsAttribute("http://localhost:35303", "*", "*");
            config.EnableCors(cors);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var appXmlType =
               config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            config.MessageHandlers.Add(
                new ZumoAuthenticationHandler());
        }
    }
}
