using System.Collections.Generic;

namespace AgilleApi.Domain.Services.Specialize;

public class PopulateTemplateService
{
    public static string Populate(string template, Dictionary<string, string> data)
    {
        foreach(var pair in data)
            ReplaceIfNotNull(ref template, pair);

        return template;
    }

    private static void ReplaceIfNotNull(ref string notice, KeyValuePair<string, string> pair)
    {
        if (string.IsNullOrEmpty(pair.Value) || string.IsNullOrEmpty(pair.Key))
            return;

        notice = notice.Replace(pair.Key, pair.Value);
    }
}