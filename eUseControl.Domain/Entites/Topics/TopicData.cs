using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.Domain.Entites.Topics
{
    public class TopicData
    {
        public int TopicID { get; set; }
        public string Title { get; set; }
        public List<SubjectData> Subjects { get; set; }
    }
}
