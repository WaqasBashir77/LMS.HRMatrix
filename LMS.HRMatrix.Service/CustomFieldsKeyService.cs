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
    
    public interface ICustomFieldKeyService
    {
        IEnumerable<CustomFieldKey> GetAll();
        CustomFieldKey GetById(int id);
        CustomFieldKey GetByKeyDetail(int id);
        void Create(CustomFieldKey employee);
        void Delete(CustomFieldKey employee);
        void Update(CustomFieldKey employee);
        IEnumerable<CustomFieldKey> GetByKeyId(int KeyId);
        CustomFieldKey GetCustomFieldNameToKey(string keyName);
        void Save();
    }

    public class CustomFieldKeyService : ICustomFieldKeyService
    {
        private readonly ICustomFieldKeysRepository CustomFieldKeyRepository;
        private readonly IUnitOfWork unitOfWork;

        public CustomFieldKeyService(ICustomFieldKeysRepository CustomFieldKeyRepository, IUnitOfWork unitOfWork)
        {
            this.CustomFieldKeyRepository = CustomFieldKeyRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IEmployeeService Members  
        public IEnumerable<CustomFieldKey> GetAll()
        {

            return CustomFieldKeyRepository.GetAll();
        }
        public CustomFieldKey GetByKeyDetail(int keyId)
        {
            return CustomFieldKeyRepository.Get(o => o.CustomFieldID == keyId);
        }
        public CustomFieldKey GetCustomFieldNameToKey(string keyName)
        {
            return CustomFieldKeyRepository.Get(o => o.Name == keyName);
        }
        public CustomFieldKey GetById(int id)
        {
            return CustomFieldKeyRepository.GetById(id);
        }
        public IEnumerable<CustomFieldKey> GetByKeyId(int KeyId)
        {
            return CustomFieldKeyRepository.GetByKeyId(KeyId);

        }
        public void Create(CustomFieldKey employee)
        {
            CustomFieldKeyRepository.Add(employee);
        }
        public void Delete(CustomFieldKey employee)
        {

            CustomFieldKeyRepository.Delete(employee);
        }
        public void Update(CustomFieldKey employee)
        {
            CustomFieldKeyRepository.Update(employee);
        }
        public void Save()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
