using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using HRManagementSystem;
using HRManagementSystem.Models;

namespace HRManagementSystem
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

           
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            //----employee------
    builder.EntitySet<EmployeeDetail>("EmployeeDetails");
    builder.EntitySet<AttendenceDetail>("AttendenceDetails"); 
    builder.EntitySet<SalaryDetail>("SalaryDetails");
//---candidate-----
    builder.EntitySet<Candidate_Detail>("Candidate_Detail");
//---------tblCalender---------
   
            //--------------EmpLogin----------
    builder.EntitySet<EmployeeLogin>("EmployeeLogins");
    //        //----------------EduDetail----------
    //builder.EntitySet<educationDetail>("educationDetails");
    //builder.EntitySet<Candidate_Detail>("Candidate_Details"); 
            //----------JobPost-----------
    builder.EntitySet<JobPosted>("JobPosteds");
            //---------------------------


    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
