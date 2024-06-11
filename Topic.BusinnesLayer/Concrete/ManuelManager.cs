using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.BusinnesLayer.Abstract;
using Topic.DataAccsesLayer.Abstract;
using Topic.EntityLayer.Entities;

namespace Topic.BusinnesLayer.Concrete
{
    public class ManuelManager : GenericManager<Manuel>, IManuelService
    {
        public ManuelManager(IGenericDal<Manuel> genericDal) : base(genericDal)
        {
        }
    }
}
