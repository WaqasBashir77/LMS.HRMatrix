using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LMS.HRMatrix.Model;
using LMS.HRMatrix.Service;
using LMS.HRMatrix.UI.ViewModels;
using LMS.HRMatrix.ViewModels;

namespace LMS.HRMatrix.UI.Controllers
{
    public class CustomFieldKeyController : Controller
    {
        private readonly ICustomFieldKeyService CustomFieldKeyService;
        private readonly ICustomFieldKeyValueService customfieldKeyValueService;
        private readonly ICustomFieldService CustomFieldService;
        // private readonly IMyDictionaryService myDictionaryService;
        public CustomFieldKeyController(ICustomFieldKeyService CustomFieldKeyService, ICustomFieldService CustomFieldService, ICustomFieldKeyValueService customfieldKeyValueService)
        {
            this.CustomFieldKeyService = CustomFieldKeyService;
            this.customfieldKeyValueService = customfieldKeyValueService;
            this.CustomFieldService =  CustomFieldService;
        }

        // GET: CustomFieldKey
        public ActionResult Index()
        {
            
            IEnumerable<CustomFields> customFields = CustomFieldService.GetByOrgId(1);
            IEnumerable<CustomFields> customKey = new List<CustomFields>();

            var customFieldKeys = new List<CustomFieldKey>();
            foreach (var x in customFields)
            {
                customFieldKeys.Add(CustomFieldKeyService.GetByKeyDetail(x.CustomFieldID));
            }
            return View(customFieldKeys);
           
        }

         [HttpPost]
        public ActionResult AddFieldKey(CustomFieldKeyViewModel customFieldKeyViewModel)
        {
           if (ModelState.IsValid)
            {
                CustomFields obj=new CustomFields();
                obj.OrgId = 1;
                CustomFieldService.Create(obj);
                CustomFieldService.Save();
                var ID = obj.CustomFieldID;
                var customFieldKey = Mapper.Map<CustomFieldKeyViewModel, CustomFieldKey>(customFieldKeyViewModel);
                customFieldKey.CustomFieldID = ID;
                CustomFieldKeyService.Create(customFieldKey);
                CustomFieldKeyService.Save();
                return Json("true");
            }
            return Json("False");
        }
        /*T GetObject<T>(Dictionary<string, string> dict)
        {
            Type type = typeof(T);
            var obj = Activator.CreateInstance(type);

            foreach (var kv in dict)
            {
                type.GetProperty(kv.Key).SetValue(obj, kv.Value);
            }
            return (T)obj;
        }*/
        public ActionResult CustomFieldDeleteOnJsonRequest(int id)
        {
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    CustomFieldKey CFK = CustomFieldKeyService.GetById(id);
                    var customfieldkey = Mapper.Map<CustomFieldKey, CustomFieldKey>(CFK);
                    CustomFieldKeyService.Delete(customfieldkey);
                    CustomFieldKeyService.Save();
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
        public ActionResult UpdateCustomFieldKey(CustomFieldKeyViewModel customfieldKeyViewModel)
        {
            if (ModelState.IsValid)
            {
                var customfieldkey = Mapper.Map<CustomFieldKeyViewModel, CustomFieldKey>(customfieldKeyViewModel);
                CustomFieldKeyService.Update(customfieldkey);
                CustomFieldKeyService.Save();
                return Json("True");
            }
            return Json("False");
        }
        public ActionResult customfieldkeyOnJsonRequest(int id)
        {
            try
            {
                CustomFieldKey customfielkey = CustomFieldKeyService.GetById(id);
                string[] array = new string[6];
                array[0] = customfielkey.CustomFieldKeyId.ToString();
                array[1] = customfielkey.Name.ToString();
                array[2] = customfielkey.type.ToString();
                array[3] = customfielkey.DefaultValue.ToString();
                array[4] = customfielkey.MaxValue.ToString();
                array[5] = customfielkey.MinValue.ToString();
                
                return Json(array, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                return null;
            }
        }
        [HttpPost]
        public ActionResult AddFieldKeyValues(CustomFieldKeyValuesViewModel customFieldKeyValues)
        {
            if (ModelState.IsValid)
            {
                customFieldKeyValues.EmployeeId = 8;

                var KeyValues = Mapper.Map<CustomFieldKeyValuesViewModel, CustomFieldKeyValue>(customFieldKeyValues);
                customfieldKeyValueService.Create(KeyValues);
                customfieldKeyValueService.Save();
                return Json("true");
            }
            return Json("False");

        }
    }
}