using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AgilleApi.Domain.Services.Specialize.PDF.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace AgilleApi.API.Implemantation.Services
{

    //public class RazorRenderer : IRazorPageRenderer
    //{
    //    private readonly IRazorViewEngine _viewEngine;
    //    private readonly ITempDataProvider _tempDataProvider;
    //    private readonly IServiceProvider _serviceProvider;

    //    public RazorRenderer(
    //        IRazorViewEngine viewEngine,
    //        ITempDataProvider tempDataProvider,
    //        IServiceProvider serviceProvider)
    //    {
    //        _viewEngine = viewEngine;
    //        _tempDataProvider = tempDataProvider;
    //        _serviceProvider = serviceProvider;
    //    }

    //    public async Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model)
    //    {
    //        ActionContext actionContext = GetActionContext();
    //        IView view = FindView(actionContext, viewName);

    //        using (StringWriter output = new StringWriter())
    //        {
    //            ViewContext viewContext = new ViewContext(
    //                actionContext,
    //                view,
    //                new ViewDataDictionary<TModel>(new EmptyModelMetadataProvider(), new ModelStateDictionary())
    //                {
    //                    Model = model
    //                },
    //                new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
    //                output,
    //                new HtmlHelperOptions()
    //            );

    //            await view.RenderAsync(viewContext);

    //            return output.ToString();
    //        }
    //    }



    //    private IView FindView(ActionContext actionContext, string viewName)
    //    {
    //        ViewEngineResult getViewResult = _viewEngine.GetView(executingFilePath: null, viewPath: viewName, isMainPage: true);
    //        if (getViewResult.Success)
    //        {
    //            return getViewResult.View;
    //        }

    //        ViewEngineResult findViewResult = _viewEngine.FindView(actionContext, viewName, isMainPage: true);
    //        if (findViewResult.Success)
    //        {
    //            return findViewResult.View;
    //        }

    //        System.Collections.Generic.IEnumerable<string> searchedLocations = getViewResult.SearchedLocations.Concat(findViewResult.SearchedLocations);
    //        string errorMessage = string.Join(
    //            Environment.NewLine,
    //            new[] { $"Unable to find view '{viewName}'. The following locations were searched:" }.Concat(searchedLocations));

    //        throw new InvalidOperationException(errorMessage);
    //    }

    //    private ActionContext GetActionContext()
    //    {
    //        DefaultHttpContext httpContext = new DefaultHttpContext { RequestServices = _serviceProvider };
    //        return new ActionContext(httpContext,
    //        new Microsoft.AspNetCore.Routing.RouteData(),
    //        new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());
    //    }
    //}
}
