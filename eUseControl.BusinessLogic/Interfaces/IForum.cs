using eUseControl.Domain.Entites.Topics;
using System.Collections.Generic;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface IForum
    {
        CategoryResp AddCategory(CategoryData category);
        TopicResp AddTopic(TopicData topic,int id);
        SubjectResp AddSubject(SubjectData subject, int c_id, int t_id);
        List<CategoryData> GetCategoryData();
        TopicData GetTopicData(int id);
    }
}
