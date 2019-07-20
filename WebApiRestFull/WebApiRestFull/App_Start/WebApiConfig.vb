Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http

Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)
        ' Web API configuration and services        
        'routeTemplate:="api/{key:maxlength(500)}/{controller}/{action}/{id}",
        '   defaults:=New With {.Key = RouteParameter.Optional, .id = RouteParameter.Optional}

        ' Web API routes
        config.MapHttpAttributeRoutes()

        config.Routes.MapHttpRoute(
            name:="ApiWithAction",
                routeTemplate:="api/{controller}/{action}/{id}",
            defaults:=New With {.id = RouteParameter.Optional}
                        )

        config.Formatters.JsonFormatter.SupportedMediaTypes.Add(New System.Net.Http.Headers.MediaTypeHeaderValue("application/json"))



    End Sub
End Module
