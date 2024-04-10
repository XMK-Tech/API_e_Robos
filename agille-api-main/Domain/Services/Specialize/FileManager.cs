using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AgilleApi.Domain.Services.Specialize
{
    public static class FileManager
    {

        //Google File Manager
        //private static readonly string projectId = "storage-pont-service";
        private static readonly string bucketName = "orders-point-service";
        private static readonly GoogleCredential credential = GoogleCredential.FromFile("storage-pont-service-30fb6e691b9e.json");


        public static async Task<Google.Apis.Storage.v1.Data.Object> UploadFileToGoogle(Stream fileStream, string fileName, string contentType)
        {
            using (StorageClient storage = StorageClient.Create(credential))
            {
                Google.Apis.Storage.v1.Data.Object patchObject = new Google.Apis.Storage.v1.Data.Object()
                {
                    Bucket = bucketName,
                    Name = fileName,
                    CacheControl = "public, max-age=3600",
                    ContentType = contentType,
                };

                return await storage.UploadObjectAsync(patchObject, fileStream);
            }

        }

        public static Task<String> GetSignedUrl(String url)
        {
            UrlSigner signer = UrlSigner.FromServiceAccountCredential(credential.UnderlyingCredential as ServiceAccountCredential);

            Uri uri = new Uri(url);

            return signer.SignAsync(bucketName, uri.Segments.Last(), TimeSpan.FromHours(0.5));
        }

    }
}
