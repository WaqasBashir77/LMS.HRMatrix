using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.HRMatrix.Data.Infrastructure;
using LMS.HRMatrix.Data.Repositories;
using LMS.HRMatrix.Model;

namespace LMS.HRMatrix.Service
{

    public interface ICustomFieldKeyValueService
    {
        IEnumerable<CustomFieldKeyValue> GetAll();
        CustomFieldKeyValue GetById(int id);
        void Create(CustomFieldKeyValue CustomFieldKeyValue);
        void Delete(CustomFieldKeyValue CustomFieldKeyValue);
        void Update(CustomFieldKeyValue CustomFieldKeyValue);
        void Save();
    }

    public class CustomFieldKeyValueService : ICustomFieldKeyValueService
    {
        private readonly ICustomFieldKeyValueRepository CustomFieldKeyValueRepository;
        private readonly IUnitOfWork unitOfWork;

        public CustomFieldKeyValueService(ICustomFieldKeyValueRepository CustomFieldKeyValueRepository,
            IUnitOfWork unitOfWork)
        {
            this.CustomFieldKeyValueRepository = CustomFieldKeyValueRepository;
            this.unitOfWork = unitOfWork;
        }

       // #region IEmployeeService Members  

        public IEnumerable<CustomFieldKeyValue> GetAll()
        {

            return CustomFieldKeyValueRepository.GetAll();
        }

        public CustomFieldKeyValue GetByWorkEmail(int employeeID)
        {
            return CustomFieldKeyValueRepository.Get(o => o.EmployeeId == employeeID);
        }

        public CustomFieldKeyValue GetById(int id)
        {
            return CustomFieldKeyValueRepository.GetById(id);
        }

        public void Create(CustomFieldKeyValue CustomFieldKeyValue)
        {
            CustomFieldKeyValueRepository.Add(CustomFieldKeyValue);
        }

        public void Delete(CustomFieldKeyValue CustomFieldKeyValue)
        {

            CustomFieldKeyValueRepository.Delete(CustomFieldKeyValue);
        }

        public void Update(CustomFieldKeyValue CustomFieldKeyValue)
        {
            CustomFieldKeyValueRepository.Update(CustomFieldKeyValue);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

    }
}

