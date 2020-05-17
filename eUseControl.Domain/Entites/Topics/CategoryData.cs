using System.Collections.Generic;

namespace eUseControl.Domain.Entites.Topics
{
    public class CategoryData
    {
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public List<TopicData> Topics { get; set; }
    }
}
