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
    
        public interface ICustomFieldService
    {
            IEnumerable<CustomFields> GetAll();
             CustomFields GetOrgId(int id);
            IEnumerable<CustomFields> GetByOrgId(int orgId);
            void Create(CustomFields CustomFields);
            void Delete(CustomFields CustomFields);
            void Update(CustomFields CustomFields);
            void Save();
        }

        public class CustomFieldService : ICustomFieldService
    {
            private readonly ICustomFieldsRepository CustomFieldsRepository;
            private readonly IUnitOfWork unitOfWork;

            public CustomFieldService(ICustomFieldsRepository CustomFieldsRepository, IUnitOfWork unitOfWork)
            {
                this.CustomFieldsRepository = CustomFieldsRepository;
                this.unitOfWork = unitOfWork;
            }

            #region IEmployeeService Members  
            public IEnumerable<CustomFields> GetAll()
            {

                return CustomFieldsRepository.GetAll();
            }

            public IEnumerable<CustomFields> GetByOrgId(int orgId)
            {

                return CustomFieldsRepository.GetByOrgId(orgId);
            }
        /// <summary>
        /// //////////////
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
            public CustomFields GetOrgId(int orgId)
            {
                return CustomFieldsRepository.Get(o => o.OrgId == orgId);
            }
            public CustomFields GetById(int id)
            {
                return CustomFieldsRepository.GetById(id);
            }

            public void Create(CustomFields CustomFields)
            {
                CustomFieldsRepository.Add(CustomFields);
            }
            public void Delete(CustomFields CustomFields)
            {

                CustomFieldsRepository.Delete(CustomFields);
            }
            public void Update(CustomFields CustomFields)
            {
                CustomFieldsRepository.Update(CustomFields);
            }
            public void Save()
            {
                unitOfWork.Commit();
            }

            #endregion
        }
    }


