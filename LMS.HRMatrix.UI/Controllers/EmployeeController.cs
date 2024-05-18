using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LMS.HRMatrix.Model;
using LMS.HRMatrix.Service;
using LMS.HRMatrix.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using LMS.HRMatrix.UI.ViewModels;

namespace LMS.HRMatrix.UI.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService employeeService;
       
        private readonly ICustomFieldKeyValueService customfieldKeyValueService;
        private readonly ICustomFieldKeyService CustomFieldKeyService;
        private readonly ICustomFieldService CustomFieldService;


        public EmployeeController(IEmployeeService employeeService , ICustomFieldService CustomFieldService, ICustomFieldKeyValueService customfieldKeyValueService, ICustomFieldKeyService CustomFieldKeyService)
        {
            this.employeeService = employeeService;
            this.customfieldKeyValueService = customfieldKeyValueService;
            this.CustomFieldKeyService = CustomFieldKeyService;
            this.CustomFieldService = CustomFieldService;


        }
        /*public EmployeeController(IMyDictionaryService myDictionaryService)
        {
            this.myDictionaryService = myDictionaryService;
        }*/
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<Employee> employee = employeeService.GetAll();
            IEnumerable<CustomFieldKeyValue> customFieldKeyValues = customfieldKeyValueService.GetAll();
            return View(Tuple.Create(employee, customFieldKeyValues));
        }

        public ActionResult GetAll([DataSourceRequest]DataSourceRequest request, string firstName)
        {
            IEnumerable<Employee> employee = employeeService.GetAll();
            IEnumerable<EmployeeViewModel> data = Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employee);
            return Json(data.ToDataSourceResult(request));
        }

        public ActionResult AddEmployee()
        {
           IEnumerable<CustomFields> customFields= CustomFieldService.GetByOrgId(1);
            IEnumerable<CustomFields> customKey = new List<CustomFields>();

            var customFieldKeys = new List<CustomFieldKey>();
            foreach (var x in customFields)
            {
                customFieldKeys.Add( CustomFieldKeyService.GetByKeyDetail(x.CustomFieldID));
            }
            return View(customFieldKeys);
        }

        public ActionResult EmployeeDeleteOnJsonRequest(int id)
        {
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    Employee emp = employeeService.GetById(id);
                    var employee = Mapper.Map<Employee, Employee>(emp);
                    employeeService.Delete(employee);
                    employeeService.Save();
                    return Json("True");
                }
                else
                {
                    return Json("False");
                }

            }
            return Json("False");
        }
        [HttpPost]
        public ActionResult CustomFieldSubmitWithModel(IDictionary<string, string> CustomField, EmployeeViewModel employee, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                ////List for View Return IDictionary
                List<string> keyValueFromIDictionary = new List<string>();
                ////Used for retrive values from form and get it in it
                IDictionary<string, string> CustomFieldValues = new Dictionary<string, string>();
                ////Get Key values from IDictionary
                foreach (var x in CustomField)
                {
                    keyValueFromIDictionary.Add(x.Key);
                }
                /////Retrive Values from the FormCollection into CustomFieldValues
                foreach (var key in form.Keys)
                {
                    foreach (var x in keyValueFromIDictionary)
                    {
                        string FieldName = "CustomField[" + x + "]";
                        /////Match key with FormCollection
                        if (key.Equals(FieldName))
                        {
                            CustomFieldValues.Add(x, form[key.ToString()]);
                        }
                    }
                }
                ////Save Employee in DB
                var employeeMaper = Mapper.Map<EmployeeViewModel, Employee>(employee);
                employeeService.Create(employeeMaper);
                employeeService.Save();
                var employeeMaperId = employeeMaper.Id;
                //// Save Employee Custom Fields into the DB
                foreach (var x in CustomFieldValues)
                {
                    var CustomFieldKey = CustomFieldKeyService.GetCustomFieldNameToKey(x.Key);
                    CustomFieldKeyValue obj = new CustomFieldKeyValue();
                    obj.CustomFieldKeyId = CustomFieldKey.CustomFieldKeyId;
                    obj.EmployeeId = employeeMaperId;
                    obj.Value = x.Value;
                    customfieldKeyValueService.Create(obj);
                    customfieldKeyValueService.Save();
                }
                return View("Success");
            }
            return View("Error");
        }
        /*System.Text.StringBuilder st = new System.Text.StringBuilder();
        foreach (string key in form.Keys)
        {
            st.AppendLine(String.Format("{0} - {1}", key, form.GetValue(key).AttemptedValue));
        }
        string formValues = st.ToString();
        MyDictionaryViewModel obj = new MyDictionaryViewModel();
        foreach (var x in myDictionary)
        {
            obj.Mykey = x.Key;
            obj.Myvalue = x.Value;
            obj.EmployeeId = 8;
            var MyDictionaryObj = Mapper.Map<MyDictionaryViewModel, MyDictionary>(obj);
            myDictionaryService.Create(MyDictionaryObj);
            myDictionaryService.Save();
        }
        ViewBag.Result = formValues;*/


        [HttpPost]
        public ActionResult UpdateEmployee(EmployeeViewModel employeeViewModel, Dictionary<string, string> DictionaryData)
        {
            if (ModelState.IsValid)
            {
                var employee = Mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);
                employeeService.Update(employee);
                employeeService.Save();
                return Json("True");
            }
            return Json("False");
        }

        [HttpPost]
        public JsonResult Add(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                var employee = Mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);
                employeeService.Create(employee);
                employeeService.Save();
                return Json("true");
            }
            return Json("False");
        }
        [HttpPost]
        public ActionResult Apply(MyViewModel model)
        {
            if (ModelState.IsValid)
            {
                //do stuff. ModelState.IsValid returns false here.
            }

            return View();
        }
        public ActionResult EmployeeOnJsonRequest(int id)
        {
            try
            {
                Employee employee = employeeService.GetById(id);
                string[] array = new string[11];
                array[0] = employee.Id.ToString();
                array[1] = employee.OrganizationId.ToString();
                array[2] = employee.OnboardingId.ToString();
                array[3] = employee.Salutation.ToString();
                array[4] = employee.FirstName.ToString();
                array[5] = employee.MiddleName.ToString();
                array[6] = employee.LastName.ToString();
                array[7] = employee.NickName.ToString();
                array[8] = employee.DisplayName.ToString();
                array[9] = employee.PersonNumber.ToString();
                array[10] = employee.WorkEmail.ToString();
                return Json(array, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }

    }

}