using System.Collections.Generic;

namespace eUseControl.Web.Models.Posts
{
    public class PCategoryData
    {
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public List<PTopicData> Topics { get; set; }
    }
}