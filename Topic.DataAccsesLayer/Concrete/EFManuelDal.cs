﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.DataAccsesLayer.Abstract;
using Topic.DataAccsesLayer.Context;
using Topic.DataAccsesLayer.Repositories;
using Topic.EntityLayer.Entities;

namespace Topic.DataAccsesLayer.Concrete
{
    public class EFManuelDal : GenericRepository<Manuel>, IManuelDal
    {
        public EFManuelDal(TopicContext topicContext) : base(topicContext)
        {
        }
    }
}
