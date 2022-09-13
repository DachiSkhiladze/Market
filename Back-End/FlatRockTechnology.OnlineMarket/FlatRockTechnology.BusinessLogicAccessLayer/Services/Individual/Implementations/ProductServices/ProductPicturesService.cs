using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Implementations;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Products;
using MediatR;
using Microsoft.AspNetCore.Http;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.ProductServices;
using PicturesAccessLayer.Repository;
using Queries.Declarations.Individual;

namespace OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.ProductServices
{
    public class ProductPicturesService : BaseService<ProductPictures, ProductPicturesModel>, IProductPicturesServices
    {
        private static Random random = new();
        private readonly BlobRepository blobRepository;
        public ProductPicturesService(IMediator mediator) : base(mediator)
        {
            blobRepository = new();
        }

        public async IAsyncEnumerable<ProductPicturesModel> GetPicturesByProductId(Guid productId)
        {
            var pictures = await mediator.Send(new GetProductPicturesByProductIDQuery(productId));
            foreach (var picture in pictures)
            {
                if(picture.ImageURL != null)
                {
                    picture.ImageURL = await blobRepository.Get() + picture.ImageURL;
                }
                yield return picture;
            }
        }


        public async Task InsertAsync(IEnumerable<string> pictures, Guid productId)
        {
            if(pictures == null)
            {
                return;
            }
            List<ProductPicturesModel> picturesModels = new();
            foreach (var picture in pictures)
            {
                if (picture.Length > 0)
                {
                    string extension = "." + picture.Split('/')[1].Split(';')[0];
                    string name = GenerateName(extension);
                    if (picture.Length < 2097152)
                    {
                        ProductPicturesModel newphoto = new()
                        {
                            ImageSaveType = "Blob",
                            ImageURL = name,
                            Base64 = "----",
                            Description = "Product Image",
                            FileExtension = GetFileExtension(picture),
                            Size = picture.Length,
                            ProductId = productId,
                        };
                        //Add the photo in Azure blob
                        await blobRepository.Upload(picture, name);
                        //add the photo instance to the list.
                        picturesModels.Add(newphoto);
                    }
                    else
                    {
                        throw new Exception("File is too large");
                    }
                }
            }

            foreach (var picture in picturesModels)
            {
                // Inserting into Database
                await base.InsertAsync(picture);
            }
        }

        public static string GenerateName(string extension)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray()) + extension;
        }

        public static string GetFileExtension(string base64String)
        {
            var data = base64String.Substring(0, 5);

            switch (data.ToUpper())
            {
                case "IVBOR":
                    return "png";
                case "/9J/4":
                    return "jpg";
                case "AAAAF":
                    return "mp4";
                case "JVBER":
                    return "pdf";
                case "AAABA":
                    return "ico";
                case "UMFYI":
                    return "rar";
                case "E1XYD":
                    return "rtf";
                case "U1PKC":
                    return "txt";
                case "MQOWM":
                case "77U/M":
                    return "srt";
                default:
                    return string.Empty;
            }
        }
    }
}
