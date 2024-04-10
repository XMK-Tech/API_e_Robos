using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilleApi.Domain.Interfaces.Json;

public interface IConvertableToViewModel<ContentViewModel> where ContentViewModel : class
{
    ContentViewModel ConvertToViewModel();
}
