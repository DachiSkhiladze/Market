#nullable disable
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.Abstractions;

namespace FlatRockTechnology.OnlineMarket.DataAccessLayer.DB
{
    public partial class ProductPictures : IEntity
    {
        public Guid Id { get; set; }
        public string ImageSaveType { get; set; }
        public string Base64 { get; set; }
        public string ImageURL { get; set; }
        public Guid ProductId { get; set; }
        public byte[] Bytes { get; set; }
        public string Description { get; set; }
        public string FileExtension { get; set; }
        public double Size { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
