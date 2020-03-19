using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;

namespace eUseControl.BusinessLogic.LogicBL
{
    class SessionBL : ApiUser , ISession 
    {
        public bool GetUserSessionStatus()
        {
            return true;
        }
    }
}
