using AgilleApi.API.ControllersResult.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace AgilleApi.API.ControllersResult
{
    public class ModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new RedirectToRouteResult(ConstructResult(context.ModelState));
            }
            else
            {
                base.OnActionExecuting(context);
            }
        }

        private ActionResult<Result<WithOutContent>> ConstructResult(ModelStateDictionary ModelState)
        {
            return new Result<WithOutContent>(400, ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage).ToList());
        }
    }
}
