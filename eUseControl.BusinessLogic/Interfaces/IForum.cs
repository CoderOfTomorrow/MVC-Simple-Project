using eUseControl.Domain.Entites.Topics;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface IForum
    {
        CategoryResp AddCategory(CategoryData category);
        TopicResp AddTopic(TopicData topic,int id);
        SubjectResp AddSubject(SubjectData subject);
    }
}
