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

        public IForum GetForumBL()
        {
            return new ForumBL();
        }

        public IGalerie GetGalerieBL()
        {
            return new GalerieBL();
        }
    }
}
