using Library.Service.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebAPI.Filters.ActionFilters
{
    public class BookEntityExistsAttribute : IAsyncActionFilter
    {
        private IBookService _bookService;
        public BookEntityExistsAttribute (IBookService bookService)
        {
            _bookService = bookService;
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

            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("book", book);
            }

            var result = await next();
        }
    }
}
