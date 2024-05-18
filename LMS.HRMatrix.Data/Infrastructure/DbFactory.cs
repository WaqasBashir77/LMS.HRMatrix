using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.HRMatrix.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        HRMatrixEntities dbContext;

        public HRMatrixEntities Init()
        {
            return dbContext ?? (dbContext = new HRMatrixEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
