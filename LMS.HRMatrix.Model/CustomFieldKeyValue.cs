using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.HRMatrix.Model
{
   public class CustomFieldKeyValue
    {
        [Key]
        public int CustomFieldKeyValueID { get; set; }
        public string Value { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int CustomFieldKeyId { get; set; }
        public CustomFieldKey CustomFieldKey { get; set; }
    }
}
