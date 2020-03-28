using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entites.User;

namespace eUseControl.BusinessLogic.LogicBL
{
    public class RegisterBL : ApiUser , IRegister
    {
        public URegisterResp UserRegister(URegisterData data)
        {
            return UserRegisterAction(data);
        }
    }
}
