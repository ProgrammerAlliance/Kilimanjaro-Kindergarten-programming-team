﻿using NLC.YummyCate.DAL;
using NLC.YummyCate.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.YummyCate.DALFactory
{
  public  class OrderDALFactory
    {
        public static IOrderDAL CreateOrderDAL()
        {
            return new OrderDAL();
        }
    }
}
