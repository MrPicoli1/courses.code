﻿using Store.Domain.Entities;
using Store.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Test.Repositories
{
    public class FakeOrderRepository : IOrderRepository
    {
        public void Save(Order order)
        {

        }
    }
}
