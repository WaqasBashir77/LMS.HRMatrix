using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.HRMatrix.Data.Infrastructure;
using LMS.HRMatrix.Model;

namespace LMS.HRMatrix.Data.Repositories
{
    public class CustomFieldKeyValueRepository : RepositoryBase<CustomFieldKeyValue>, ICustomFieldKeyValueRepository
    {
        public CustomFieldKeyValueRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
    public interface ICustomFieldKeyValueRepository : IRepository<CustomFieldKeyValue>
    {

    }
}
