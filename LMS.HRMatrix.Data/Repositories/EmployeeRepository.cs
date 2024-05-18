using LMS.HRMatrix.Data.Infrastructure;
using LMS.HRMatrix.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.HRMatrix.Data.Repositories
{

    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
    public interface IEmployeeRepository : IRepository<Employee>
    {
        
    }
}
