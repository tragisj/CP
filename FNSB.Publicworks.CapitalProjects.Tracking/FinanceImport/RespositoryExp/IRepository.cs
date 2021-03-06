﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNSB.PW.Finance.Import.RespositoryExp
{
    public  interface IRepository<T>
    {
        void Calculate(T entity);
        IQueryable<T> GetAll();
    }
}
