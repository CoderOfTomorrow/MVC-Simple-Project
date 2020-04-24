using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eUseControl.Web.Models
{
    public class ImageData
    {
        public int ImageID { get; set; }

        public string Title { get; set; }

        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}