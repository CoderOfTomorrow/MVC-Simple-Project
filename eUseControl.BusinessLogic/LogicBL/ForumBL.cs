using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entites.Topics;
using System.Collections.Generic;

namespace eUseControl.BusinessLogic.LogicBL
{
    public class ForumBL : ApiUser, IForum
    {
        public CategoryResp AddCategory(CategoryData category)
        {
            return AddCategoryAction(category);
        }

        public TopicResp AddTopic(TopicData topic,int id)
        {
            return AddTopicAction(topic,id);
        }

        public SubjectResp AddSubject(SubjectData subject,int c_id,int t_id)
        {
            return AddSubjectAction(subject,c_id,t_id);
        }

        public List<CategoryData> GetCategoryData()
        {
            return GetCategoryDataApi();
        }

        public TopicData GetTopicData(int id)
        {
            return GetTopicDataApi(id);
        }
    }
}
