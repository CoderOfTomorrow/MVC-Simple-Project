using System.Collections.Generic;
using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entites.Images;

namespace eUseControl.BusinessLogic.LogicBL
{
    public class GalerieBL : ApiUser , IGalerie
    {
        public List<Image> GetGalerieData()
        {
            return GetGalerieDataApi();
        }
    }
}
