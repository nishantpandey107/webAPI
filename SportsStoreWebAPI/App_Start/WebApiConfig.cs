﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

using System.Web.Http.Cors;

namespace SportsStoreWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            //For  Cors by MN
            //config.EnableCors();
            //var cors = new EnableCorsAttribute(origins: "http://localhost:45561", headers: "*", methods: "*");
            //config.EnableCors(cors);
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));



            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{productID}",
                defaults: new { productID = RouteParameter.Optional }
            );
        }
    }
}
