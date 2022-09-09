using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturesAccessLayer.Repository
{
    public class BlobRepository
    {
        private readonly string connectionString = "DefaultEndpointsProtocol=https;AccountName=picturesfrt;AccountKey=DadFfRkbpoZz3qQyf6boK+H972k/IilcrNauQ9hI7eju3Mz9pe9EPXfzmoLm8z/mJwdQnZNHK2Qg+AStKLQcBw==;EndpointSuffix=core.windows.net";
        private readonly string containerName = "productpictures";
        private readonly string url = "https://picturesfrt.blob.core.windows.net/productpictures/";

        BlobServiceClient blobServiceClient;
        BlobContainerClient containerClient;
        public BlobRepository()
        {
            blobServiceClient = new BlobServiceClient(connectionString);
            containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        }

        public async Task Upload(string base64, string fileName)
        {
            var encodedImage = base64.Split(',')[1];
            var decodedImage = Convert.FromBase64String(encodedImage);

            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            using (var fileStream = new MemoryStream(decodedImage))
            {
                await blobClient.UploadAsync(fileStream, true);
            }
        }

        public async Task<string> Get() => url;
    }
}
