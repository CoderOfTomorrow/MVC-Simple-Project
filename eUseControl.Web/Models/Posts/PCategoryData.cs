using System.Collections.Generic;

namespace eUseControl.Web.Models.Posts
{
    public class PCategoryData
    {
        public string Category { get; set; }
        public List<PTopicData> Topics { get; set; }
    }
}