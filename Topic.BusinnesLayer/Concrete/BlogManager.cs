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
    public class BlogManager : GenericManager<Blog>, IBlogService
    {
        public BlogManager(IGenericDal<Blog> genericDal) : base(genericDal)
        {
        }
    }
}
