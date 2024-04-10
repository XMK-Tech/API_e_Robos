using System.Threading.Tasks;

namespace AgilleApi.Domain.Services.Specialize.PDF.Interfaces
{
    public interface IRazorPageRenderer
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}
