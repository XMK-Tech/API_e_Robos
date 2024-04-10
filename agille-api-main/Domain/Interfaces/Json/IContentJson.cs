namespace AgilleApi.Domain.Interfaces.Json;

public interface IContentJson
{
    void LoadFromJson(string json);
    string ConvertToJson();
}
