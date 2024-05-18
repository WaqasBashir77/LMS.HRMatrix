using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.HRMatrix.Data.Infrastructure;
using LMS.HRMatrix.Model;

namespace LMS.HRMatrix.Data.Repositories
{
    public class CustomFieldsRepository : RepositoryBase<CustomFields>, ICustomFieldsRepository
    {
        public CustomFieldsRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public IEnumerable<CustomFields> GetByOrgId(int OrgId)
        {
            return this.DbContext.CustomFields.Where(e => e.OrgId == OrgId).ToList();
        }
    }
    public interface ICustomFieldsRepository : IRepository<CustomFields>
    {
        IEnumerable<CustomFields> GetByOrgId(int OrgId);

    }
}
