using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using WebApiDemo_Swagger.Models;
using ExceptionFilterAttribute = System.Web.Http.Filters.ExceptionFilterAttribute;

namespace WebApiDemo_Swagger.FIlters
{
    public class CustomErrorFilter : ExceptionFilterAttribute
    {
        //public override void OnException(HttpActionExecutedContext actionExecutedContext)
        //{

        //    //Check the Exception Type

        //    if (actionExecutedContext.Exception is CustomException)
        //    {
        //        //The Response Message Set by the Action During Ececution
        //        var res = actionExecutedContext.Exception.Message;

        //        //Define the Response Message
        //        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
        //        {
        //            Content = new StringContent(res),
        //            ReasonPhrase = res
        //        };


        //        //Create the Error Response

        //        actionExecutedContext.Response = response;
        //    }
        //}

        public override void OnException(HttpActionExecutedContext cntxt)
        {
            var exceptionType = cntxt.Exception.GetType();
            var res = cntxt.Exception.Message;
            var StatusCode = cntxt.Response.StatusCode;
            HttpResponseMessage response = new HttpResponseMessage()
            {
                StatusCode = StatusCode,
                // Content = new StringContent(res),
                ReasonPhrase = res
            };


        }


    }
}
