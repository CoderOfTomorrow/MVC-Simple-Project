using System.Data.Entity;
using eUseControl.Domain.Entites.User;

namespace eUseControl.BusinessLogic.DBModel
{
    public class SessionContext : DbContext
    {
        public SessionContext() : base("name=CCToolShop")
        {
        }

        public virtual DbSet<Session> Sessions { get; set; }
    }
}
