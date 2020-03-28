using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic.LogicBL;

namespace eUseControl.BusinessLogic
{
    public class BusinessLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }

        public IRegister GetRegisterBL()
        {
            return new RegisterBL();
        }
    }
}
