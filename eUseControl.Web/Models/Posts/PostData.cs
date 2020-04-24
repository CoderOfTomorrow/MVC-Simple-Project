using eUseControl.Web.Models.Posts;
using System.Collections.Generic;

namespace eUseControl.Web.Models
{
    public class PostData
    {
        public string Title { get; set; }
        public List<PCategoryData> List { get; set; }
    }
}