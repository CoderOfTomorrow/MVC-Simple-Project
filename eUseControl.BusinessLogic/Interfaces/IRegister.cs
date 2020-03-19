using eUseControl.Domain.Entites.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface IRegister
    {
        URegisterResp UserRegister(URegisterData data);
    }
}
