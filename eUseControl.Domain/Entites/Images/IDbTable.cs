using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUseControl.Domain.Entites.Images
{
    public class IDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageID { get; set; }

        public string Title { get; set; }

        public string ImagePath { get; set; }

        //public HttpPostedFileBase ImageFile { get; set; }

    }
}
