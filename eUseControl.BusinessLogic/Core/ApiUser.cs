using System.Linq;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entites.User;

namespace eUseControl.BusinessLogic.Core
{
    public class ApiUser
    {
        internal URegisterResp UserRegisterAction(URegisterData data)
        {
            UDbTable new_user = new UDbTable();

            using (var todo = new UserContext())
            {
                new_user.Username = data.Nume;
                new_user.Password = data.Parola;
                new_user.Email = data.Email;

                todo.Users.Add(new_user);
                todo.SaveChanges();
            }
            return new URegisterResp();
        }
    }
}
