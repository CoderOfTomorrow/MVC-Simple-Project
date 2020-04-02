using System.Data.Entity;
using eUseControl.Domain.Entites.Images;

namespace eUseControl.BusinessLogic.DBModel
{
    public class ImageContext : DbContext
    {
        public ImageContext() : base ("name = eUseControl")
        {
        }

        public virtual DbSet<IDbTable> Images { get; set; }
    }
}
