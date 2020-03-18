using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace eUseControl.BusinessLogic.LogicBL
{
    class SessionBL : ApiUser , ISession 
    {
        public bool GetUserSessionStatus()
        {
            return UserSessionStatus();
        }
    }
}
