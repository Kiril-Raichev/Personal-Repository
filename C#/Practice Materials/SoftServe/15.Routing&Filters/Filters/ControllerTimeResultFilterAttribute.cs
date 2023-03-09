using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Net.Http.Headers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWithRouting.Filters
{
    public class ControllerTimeResultFilterAttribute : Attribute,IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            //get operation name
            var endPointAsString = context.HttpContext.GetEndpoint().DisplayName.ToString();
            var toArray = endPointAsString.Split(new char[] { '.' },StringSplitOptions.RemoveEmptyEntries);
            var methodName = toArray.Last().ToString().Split(" ")[0];
            //add to headers
            context.HttpContext.Response.Headers.Add(methodName ,DateTime.Now.ToString());

            //foreach (var item in context.HttpContext.Response.Headers) 
            //{
            //    Console.WriteLine(item.Key + " : " + item.Value);
            //}
            await next();
        }
    }
}
