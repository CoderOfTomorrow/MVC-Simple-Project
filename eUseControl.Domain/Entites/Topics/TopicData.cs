using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUseControl.Domain.Entites.Topics
{
    public class TopicData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TopicID { get; set; }

        public string Title { get; set; }
        public List<SubjectData> Subjects { get; set; }
    }
}
