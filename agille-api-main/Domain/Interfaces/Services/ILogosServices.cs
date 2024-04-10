
namespace AgilleApi.Domain.Interfaces.Services;

public interface ILogosServices
{
    string GetUrlLogoInBase64(string url = "");
    string GetLogoinBase64ByPath(string filename);
}