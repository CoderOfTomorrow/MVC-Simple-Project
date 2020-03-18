using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic.LogicBL;
using System;
using System.Collections.Generic;
using System.Text;

namespace eUseControl.BusinessLogic
{
    public class BusinessLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }
    }
}
