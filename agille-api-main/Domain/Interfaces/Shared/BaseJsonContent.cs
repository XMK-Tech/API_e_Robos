using Newtonsoft.Json;

namespace AgilleApi.Domain.Interfaces.Shared;

public abstract class BaseJsonContent
{
    public string ConvertToJson()
    {
        return JsonConvert.SerializeObject(this);
    }

    public void LoadFromJson(string json)
    {
        if (string.IsNullOrEmpty(json))
            return;

        JsonConvert.PopulateObject(json, this);
    }
}