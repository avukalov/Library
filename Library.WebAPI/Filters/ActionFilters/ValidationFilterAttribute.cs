using Library.Models.Common.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebAPI.Filters.ActionFilters
{
    public class ValidationFilterAttribute : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var param = context.ActionArguments.SingleOrDefault(p => p.Value is IEntity);

            if(param.Value == null)
            {
                context.Result = new BadRequestObjectResult("Object is null");
                return;
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }


            var result = await next();

        }
    }
}
