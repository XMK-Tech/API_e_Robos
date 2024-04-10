using AgilleApi.Domain.ViewModel;

namespace AgilleApi.API.ControllersResult.Base
{
    public class Content<T> where T : class
    {
        public Content(T data)
        {
            this.data = data;
        }

        public T data { get; private set; }
        public Metadata metadata { get; set; }
    }
}
