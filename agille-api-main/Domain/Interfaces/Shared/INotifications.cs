using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilleApi.Domain.Interfaces.Shared
{
    public interface INotifications
    {
        List<string> ValidationMessages { get; set; }
        int StatusCode { get; set; }
        bool Valid { get { return (ValidationMessages.Count == 0); } }
    }
}
