using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.HRMatrix.Model
{
    public class CustomFieldKey
    {
        [Key]
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
