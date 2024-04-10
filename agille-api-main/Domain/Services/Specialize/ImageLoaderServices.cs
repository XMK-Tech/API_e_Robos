using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.Services.Commom;
using System;
using System.IO;

namespace AgilleApi.Domain.Services.Specialize;

public class ImageLoaderServices : IImageLoaderServices
{
    public string ConvertToBase64(string url)
    {
        if (string.IsNullOrEmpty(url))
            return "";

        var bytes = GetContent(url);
        if (bytes == null)
            return "";

        var base64 = Convert.ToBase64String(bytes);
        var type = GetImageType(url);
        return $"data:image/{type};base64,{base64}";
    }

    private static byte[] GetContent(string url)
    {
        byte[] bytes = null;

        try
        {
            bytes = ImportFileFetcher.GetFileContents(url, true);
        }
        catch(Exception ex)
        { }
        
        return bytes;
    }

    private static string GetImageType(string url)
    {
        if (string.IsNullOrEmpty(url))
            return "";

        var extension = Path.GetExtension(url).Substring(1);
        var finalIndex = extension.IndexOf("?");
        return extension[..finalIndex];
    }
}