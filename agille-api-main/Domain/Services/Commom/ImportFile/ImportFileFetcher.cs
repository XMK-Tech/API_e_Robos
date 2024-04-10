using System;
using System.Net.Http;

namespace AgilleApi.Domain.Services.Commom
{
    public class ImportFileFetcher
    {
        private readonly AttachmentServices _attachmentServices;

        public ImportFileFetcher(AttachmentServices attachmentServices)
        {
            _attachmentServices = attachmentServices;
        }

        public ImportFileFetcher() {}

        public virtual string GetFileContents(Guid? attachmentId)
        {
            if (attachmentId == null)
                return "";

            var attachment = _attachmentServices.View((Guid)attachmentId);
            var url = attachment.Url;
            
            return GetFileContents(url);
        }

        public static byte[] GetFileContents(string url, bool asByteArray)
        {
            if (string.IsNullOrEmpty(url))
                return null;

            using (var client = new HttpClient())
            {
                using var result = client.GetAsync(url).Result;
                if (result.IsSuccessStatusCode)
                    return result.Content.ReadAsByteArrayAsync().Result;
            }

            return null;
        }

        public static string GetFileContents(string url)
        {
            if (string.IsNullOrEmpty(url))
                return "";

            using (var client = new HttpClient())
            {
                using var result = client.GetAsync(url).Result;
                if (result.IsSuccessStatusCode)
                    return result.Content.ReadAsStringAsync().Result;
            }

            return "";
        }
    }
}