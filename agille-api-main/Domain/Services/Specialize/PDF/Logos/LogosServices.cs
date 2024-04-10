using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Services;
using System;
using System.IO;

namespace AgilleApi.Domain.Services.Specialize
{
    public class LogosServices : ILogosServices
    {
        private readonly IImageLoaderServices _imageLoaderServices;
        private readonly string LogoUrl = "https://storage.googleapis.com/download/storage/v1/b/agille/o/6051a003-d4dc-45a6-b0ff-0343473dd14c.png?generation=1686876977713620&alt=media";

        public LogosServices(IImageLoaderServices imageLoaderServices)
        {
            _imageLoaderServices = imageLoaderServices;
        }

        public string GetUrlLogoInBase64(string url = "")
        {
            return _imageLoaderServices.ConvertToBase64(string.IsNullOrEmpty(url) ? LogoUrl : url);
        }

        //not yet tested
        public string GetLogoinBase64ByPath(string filename)
        {
            //The idea is for the logo files to be stored in the Logos folder next to the service
            string mapPath = Environment.ExpandEnvironmentVariables("~/Domain/Services/Specialize/PDF/Logos/" + filename);
            FileStream reader = new FileStream(mapPath, FileMode.Open, FileAccess.Read);

            byte[] buffer = new byte[reader.Length];
            reader.Read(buffer, 0, (int)reader.Length);
            return Convert.ToBase64String(buffer);
        }
    }
}
