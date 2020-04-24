using System.Collections.Generic;

namespace eUseControl.Web.Models.Posts
{
    public class PTopicData
    {
        public string Title { get; set; }
        public List<PSubjectData> Subjects { get; set; }
    }
}