using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entites.Topics;

namespace eUseControl.BusinessLogic.LogicBL
{
    public class ForumBL : ApiUser, IForum
    {
        public CategoryResp AddCategory(CategoryData category)
        {
            return AddCategoryAction(category);
        }

        public TopicResp AddTopic(TopicData topic)
        {
            return AddTopicAction(topic);
        }

        public SubjectResp AddSubject(SubjectData subject)
        {
            return AddSubjectAction(subject);
        }
    }
}
