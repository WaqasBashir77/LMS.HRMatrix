using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.HRMatrix.Model
{
        public    class CustomFields
    {
        [Key]
        public int CustomFieldID { get; set; }
        public int OrgId { get; set; }
        
    }
}
