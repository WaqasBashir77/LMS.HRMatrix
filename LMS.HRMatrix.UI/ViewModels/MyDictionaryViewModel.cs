using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LMS.HRMatrix.Model;

namespace LMS.HRMatrix.UI.ViewModels
{
   
    
    
        public class MyDictionaryViewModel
        {

            public int Id { get; set; }
            public string Mykey { get; set; }
            public string Myvalue { get; set; }
            public int EmployeeId { get; set; }
            public Employee Employee { get; set; }
        /*public string WorkEmail { get; set; }*/

        /*
        [Display(Name = "Name")]
        public string DisplayName
        {
            get
            {
                string str = !string.IsNullOrEmpty(this.FirstName) ? this.FirstName : string.Empty;
                str += !string.IsNullOrEmpty(this.MiddleName) ? " " + this.MiddleName : string.Empty;
                str += !string.IsNullOrEmpty(this.LastName) ? " " + this.LastName : string.Empty;
                return str;
            }
        }
*/

        /*public string Street
        {
            get
            {

                string str = string.Empty;
                if (!string.IsNullOrWhiteSpace(this.Street1))
                    str += this.Street1;
                if (!string.IsNullOrWhiteSpace(str))
                    str += !string.IsNullOrWhiteSpace(str) ? ", " + this.Street2 : this.Street2;
                return str;
            }
        }*/
    }
    }
