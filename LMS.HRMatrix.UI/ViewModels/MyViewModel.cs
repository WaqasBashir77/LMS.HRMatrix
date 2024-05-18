using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS.HRMatrix.Model;

namespace LMS.HRMatrix.UI.ViewModels
{
    public class MyViewModel
    {
        public Employee Employee { get; set; }
        public Dictionary<string, string> myDictionary = new Dictionary<string, string>();

    }
}