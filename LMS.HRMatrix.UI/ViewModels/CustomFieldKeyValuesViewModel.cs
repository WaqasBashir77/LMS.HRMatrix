using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS.HRMatrix.Model;

namespace LMS.HRMatrix.UI.ViewModels
{
    public class CustomFieldKeyValuesViewModel
    {
        public int CustomFieldKeyValueID { get; set; }
        public string Value { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int CustomFieldKeyId { get; set; }
        public CustomFieldKey CustomFieldKey { get; set; }
    }
}