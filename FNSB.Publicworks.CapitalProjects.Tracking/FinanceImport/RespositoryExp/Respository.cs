using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNSB.PW.Finance.Import.RespositoryExp
{
    class Respository<T> : IRepository<T> where T : class, IEntity
    {
        public void Calculate(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
