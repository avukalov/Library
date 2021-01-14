using Library.DAL;
using Library.Models.Common.Utilities;
using Library.Repository.Common;
using Library.Service.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebAPI.Filters.ActionFilters
{
    public class AuthorEntityExistsAttribute : IAsyncActionFilter
    {
        private readonly IAuthorService _authorService;

        public AuthorEntityExistsAttribute(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Guid id = Guid.Empty;

            if (context.ActionArguments.ContainsKey("id"))
            {
                id = (Guid)context.ActionArguments["id"];
            }
            else
            {
                context.Result = new BadRequestObjectResult("Bad id parameter");
            }

            var author = await _authorService.GetAuthorByIdAsync(id);

            if (author.Data == null)
            {
                context.Result = new NotFoundResult();
                return;
            }
            else
            {
                context.HttpContext.Items.Add("author", author.Data);
                await next();
            }

            
        }
    }
}
