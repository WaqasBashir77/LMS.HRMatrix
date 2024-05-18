using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS.HRMatrix.Model;

namespace LMS.HRMatrix.UI.ViewModels
{
    public class CustomFieldKeyViewModel
    {
        public int CustomFieldKeyId { get; set; }
        public string Name { get; set; }
        public string type { get; set; }
        public string DefaultValue { get; set; }
        public string MinValue { get; set; }
        public string MaxValue { get; set; }
        public int CustomFieldID { get; set; }
        public ICollection<CustomFields> CustomFields { get; set; }
    }
}