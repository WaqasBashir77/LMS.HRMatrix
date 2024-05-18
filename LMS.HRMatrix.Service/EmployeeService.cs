using LMS.HRMatrix.Data.Infrastructure;
using LMS.HRMatrix.Data.Repositories;
using LMS.HRMatrix.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.HRMatrix.Service
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        void Create(Employee employee);
        void Delete(Employee employee);
        void Update(Employee employee);
        void Save();
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IUnitOfWork unitOfWork;

        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            this.employeeRepository = employeeRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IEmployeeService Members  
        public IEnumerable<Employee> GetAll()
        {

            return employeeRepository.GetAll();
        }
        public Employee GetByWorkEmail(string workemail)
        {
            return employeeRepository.Get(o => o.WorkEmail == workemail);
        }
        public Employee GetById(int id)
        {
            return employeeRepository.GetById(id);
        }

        public void Create(Employee employee)
        {
            employeeRepository.Add(employee);
        }
        public void Delete(Employee employee)
        {
            
            employeeRepository.Delete(employee);
        }
        public void Update(Employee employee)
        {
            employeeRepository.Update(employee);
        }
        public void Save()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
