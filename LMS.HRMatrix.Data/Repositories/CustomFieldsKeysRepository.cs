using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.HRMatrix.Data.Infrastructure;
using LMS.HRMatrix.Model;

namespace LMS.HRMatrix.Data.Repositories
{
   
    public class CustomFieldKeyRepository : RepositoryBase<CustomFieldKey>, ICustomFieldKeysRepository
    {
        public CustomFieldKeyRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public IEnumerable<CustomFieldKey> GetByKeyId(int KeyId)
        {
            return this.DbContext.CustomFieldKeys.Where(e => e.CustomFieldID == KeyId).ToList();
        }
    }
    public interface ICustomFieldKeysRepository : IRepository<CustomFieldKey>
    {
        IEnumerable<CustomFieldKey> GetByKeyId(int KeyId);
    }
}
