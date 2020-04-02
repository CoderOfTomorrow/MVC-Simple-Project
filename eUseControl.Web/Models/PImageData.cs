using System.Collections.Generic;
using System.Web;

namespace eUseControl.Web.Models
{
    public class PImageData
    {
        public ImageData Image { get; set; }
        public List<ImageData> ImageList { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}