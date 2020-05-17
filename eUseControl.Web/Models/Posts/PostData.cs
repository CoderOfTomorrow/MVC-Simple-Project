using eUseControl.Domain.Entites.Topics;
using eUseControl.Web.Models.Posts;
using System.Collections.Generic;

namespace eUseControl.Web.Models
{
    public class PostData
    {   
        public int Id { get; set; }
        public string Title { get; set; }
        public List<PCategoryData> CList { get; set; }
        public List<PTopicData> TList { get; set; }
        public List<PSubjectData> SList { get; set; }
    }
}