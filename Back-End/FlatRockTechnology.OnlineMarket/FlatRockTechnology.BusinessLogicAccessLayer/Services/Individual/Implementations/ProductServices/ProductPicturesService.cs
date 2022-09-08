using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Implementations;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Products;
using MediatR;
using Microsoft.AspNetCore.Http;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.ProductServices;
using Queries.Declarations.Individual;

namespace OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.ProductServices
{
    public class ProductPicturesService : BaseService<ProductPictures, ProductPicturesModel>, IProductPicturesServices
    {
        public ProductPicturesService(IMediator mediator) : base(mediator)
        {

        }

        public async Task<IEnumerable<ProductPicturesModel>> GetPicturesByProductId(Guid productId)
        {
            return await mediator.Send(new GetProductPicturesByProductIDQuery(productId));
        }


        public async Task InsertAsync(IEnumerable<string> Files, Guid productId)
        {
            if(Files == null)
            {
                return;
            }
            List<ProductPicturesModel> pictures = new List<ProductPicturesModel>();
            foreach (var formFile in Files)
            {
                if (formFile.Length > 0)
                {
                        //var extension = formFile.Split('/')[1].Split(';')[0];
                        //var rawBase64 = formFile.Split(',')[1];
                        if (formFile.Length < 2097152)
                        {
                            //based on the upload file to create Photo instance.
                            //In future I can also check the database, whether the image exists in the database.
                            var newphoto = new ProductPicturesModel()
                            {
                                ImageSaveType = "Base64",
                                Base64 = formFile,
                                Description = "Product Image",
                                FileExtension = GetFileExtension(formFile),
                                Size = formFile.Length,
                                ProductId = productId,
                            };
                            //add the photo instance to the list.
                            pictures.Add(newphoto);
                        }
                        else
                        {
                            throw new Exception("File is too large");
                        }
                }
            }

            foreach (var picture in pictures)
            {
                // Inserting into Database
                await base.InsertAsync(picture);
            }
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
