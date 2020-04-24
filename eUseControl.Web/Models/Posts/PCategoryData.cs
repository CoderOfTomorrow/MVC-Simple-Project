using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eUseControl.Web.Models.Posts
{
    public class PCategoryData
    {
        public string Title { get; set; }
        public List<PTopicData> Topics { get; set; }
    }
}