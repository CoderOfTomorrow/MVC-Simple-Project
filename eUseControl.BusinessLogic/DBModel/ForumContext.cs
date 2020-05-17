using System.Data.Entity;
using eUseControl.Domain.Entites.Topics;

namespace eUseControl.BusinessLogic.DBModel
{
    public class ForumContext : DbContext
    {
        public ForumContext() : base("name=eUseControl")
        {
        }

        public virtual DbSet<Forum> Forum { get; set; }
        public virtual DbSet<FTopic> Topic { get; set; }
        public virtual DbSet<FSubject> Subject { get; set; }
    }
}
