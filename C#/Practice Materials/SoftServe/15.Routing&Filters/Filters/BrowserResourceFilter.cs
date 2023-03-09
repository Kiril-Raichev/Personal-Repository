
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductsWithRouting.Controllers;
using System;
using System.Threading.Tasks;
using UAParser;


namespace ProductsWithRouting.Filters
{
    public class BrowserResourceFilter : IAsyncResourceFilter
    {
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            //Get browser name
            var userAgent = context.HttpContext.Request.Headers["User-Agent"];
            string uaString = Convert.ToString(userAgent);
            var uaParser = Parser.GetDefault();
            ClientInfo c = uaParser.Parse(uaString);
            //Restriction based on browser
            if (c.UserAgent.Family.ToString() != "Chrome")
            {
                throw new Exception("App can only run in Chrome!");
            }


            await next();
        }
    }
}
