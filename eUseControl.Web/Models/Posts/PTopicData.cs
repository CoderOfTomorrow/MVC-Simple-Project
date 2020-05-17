using System.Collections.Generic;

namespace eUseControl.Web.Models.Posts
{
    public class PTopicData
    {
        public int TopicID { get; set; }
        public string Title { get; set; }
        public List<PSubjectData> Subjects { get; set; }
    }
}