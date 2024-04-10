using System.Collections.Generic;
using System.Dynamic;

namespace AgilleApi.Domain.Extensions;

public static class DynamicExtensions
{
    public static bool HasProperty(dynamic obj, string propertyName)
    {
        if (obj is ExpandoObject)
            return ((IDictionary<string, object>)obj).ContainsKey(propertyName);

        return obj.GetType().GetProperty(propertyName) != null;
    }
}