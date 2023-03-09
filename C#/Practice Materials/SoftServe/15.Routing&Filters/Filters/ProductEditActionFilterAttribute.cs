using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;
using ProductsWithRouting.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;
using Wangkanai.Extensions;

namespace ProductsWithRouting.Filters
{
    public class ProductEditActionFilterAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //Check for empty field
            if (!String.IsNullOrEmpty(context.ModelState["Description"].RawValue.ToString()))
            {
                //Different Validations
                if (context.ModelState["Description"].RawValue.ToString().Length < 3
                    || !context.ModelState["Description"].RawValue.ToString().StartsWith(context.ModelState["Name"].RawValue.ToString())
                    || context.ModelState["Description"].RawValue.ToString().EqualsInvariant(context.ModelState["Name"].RawValue.ToString()))
                {
                    context.ModelState.AddModelError("Description", "");

                    string result = context.ModelState["Name"].RawValue.ToString() + "Description";

                    context.ModelState.SetModelValue("Description", new ValueProviderResult(result, CultureInfo.InvariantCulture));
                }
            }
            await next();

        }

    }
}
