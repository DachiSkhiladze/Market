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

        public async IAsyncEnumerable<string> GetPicturesByProductId(Guid productId)
        {
            var col = await mediator.Send(new GetProductPicturesByProductIDQuery(productId));
            foreach (var model in col)
            {
                yield return $"data:image/{model.FileExtension.Remove(0, 1)};base64," + Convert.ToBase64String(model.Bytes);
            }
        }


        public async Task InsertAsync(IFormFileCollection Files, Guid productId)
        {
            List<ProductPicturesModel> pictures = new List<ProductPicturesModel>();
            foreach (var formFile in Files)
            {
                if (formFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await formFile.CopyToAsync(memoryStream);
                        // Upload the file if less than 2 MB
                        if (memoryStream.Length < 2097152)
                        {
                            //based on the upload file to create Photo instance.
                            //In future I can also check the database, whether the image exists in the database.
                            var newphoto = new ProductPicturesModel()
                            {
                                Bytes = memoryStream.ToArray(),
                                Description = formFile.FileName,
                                FileExtension = Path.GetExtension(formFile.FileName),
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
            }

            foreach (var picture in pictures)
            {
                // Inserting into Database
                await base.InsertAsync(picture);
            }
        }
    }
}
