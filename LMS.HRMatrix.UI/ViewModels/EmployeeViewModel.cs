using LMS.HRMatrix.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMS.HRMatrix.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public int OnboardingId { get; set; }
        public int OrganizationId { get; set; }
        [StringLength(50, ErrorMessage = "Salutation cannot be longer than 50 characters.")]
        public string Salutation { get; set; }
        [Required(ErrorMessage = "Please enter your first name ")]
        [StringLength(75, ErrorMessage = "First name cannot be longer than 75 characters.")]
        public string FirstName { get; set; }
        [StringLength(50, ErrorMessage = "Middle name cannot be longer than 50 characters.")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Please enter your last name ")]
        [StringLength(75, ErrorMessage = "Last name cannot be longer than 75 characters.")]
        public string LastName { get; set; }
        [Display(Name = "Nick Name")]
        [StringLength(50, ErrorMessage = "Middle name cannot be longer than 50 characters.")]
        public string NickName { get; set; }
        [Display(Name = "Employee #")]
        [StringLength(20, ErrorMessage = "Person number cannot be longer than 20 characters.")]
        public string PersonNumber { get; set; }
        [Required(ErrorMessage = "Please enter your email address ")]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{3,6}$", ErrorMessage = "E-mail is not valid")]
        [StringLength(50, ErrorMessage = "Work email cannot be longer than 50 characters.")]
       public string WorkEmail { get; set; }
        /*[Display(Name = "Location")]
       public Nullable<int> LocationId { get; set; }
       [Display(Name = "Division")]
       public Nullable<int> DivisionId { get; set; }
       [Display(Name = "Department")]
       public Nullable<int> DepartmentId { get; set; }
       [Display(Name = "Job Title")]
       public Nullable<int> JobTitleId { get; set; }
       [Display(Name = "Reports To")]
       public Nullable<int> ReportsToId { get; set; }
       [Display(Name = "Employment Status")]
       public Nullable<int> EmploymentStatusId { get; set; }
       [Display(Name = "Pay Rate")]
       public Nullable<int> PayRate { get; set; }
       [Display(Name = "Pay Type")]
       public Nullable<int> PayType { get; set; }
       [Display(Name = "Ethnicity")]
       public Nullable<int> EthnicityId { get; set; }
       [Display(Name = "EEO Job Category")]
       public Nullable<int> EEOJobCategoryId { get; set; }
       public Nullable<int> VeteranStatus { get; set; }
       [Display(Name = "Home Email")]
       [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{3,6}$", ErrorMessage = "E-mail is not valid")]
       [StringLength(50, ErrorMessage = "Home email cannot be longer than 50 characters.")]
       public string HomeEmail { get; set; }
       [Display(Name = "SSN")]
       [StringLength(20, ErrorMessage = "SSNumber cannot be longer than 20 characters.")]
       public string SSNumber { get; set; }
       [Display(Name = "SIN")]
       [StringLength(20, ErrorMessage = "SINumber cannot be longer than 20 characters.")]
       public string SINumber { get; set; }
       [Display(Name = "NIN")]
       [StringLength(20, ErrorMessage = "NINumber cannot be longer than 20 characters.")]
       public string NINumber { get; set; }
       [Display(Name = "Tax File Number")]
       [StringLength(20, ErrorMessage = "Tax file number cannot be longer than 20 characters.")]
       public string TaxFileNumber { get; set; }
       public DateTime CreationDate { get; set; }
       [Display(Name = "Nationality")]
       public Nullable<int> NationalityId { get; set; }*/
        /*public DateTime LastUpdateDate { get; set; }
        [StringLength(10, ErrorMessage = "Blood group cannot be longer than 10 characters.")]
        public string BloodGroup { get; set; }
        [StringLength(20, ErrorMessage = "Gender cannot be longer than 20 characters.")]
        public string Gender { get; set; }
        [Display(Name = "Marital Status")]
        public Nullable<int> MaritalStatusId { get; set; }
        public List<SelectListItem> MaritalStatusList { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> DateOfBirth { get; set; }
        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> HireDate { get; set; }
        [Display(Name = "Phone")]
        [StringLength(20, ErrorMessage = "Work phone cannot be longer than 20 characters.")]
        public string WorkPhone { get; set; }
        [Display(Name = "Ext")]
        [StringLength(20, ErrorMessage = "Work ext cannot be longer than 20 characters.")]
        public string WorkExt { get; set; }
        */
        /*[Display(Name = "Mobile Phone")]
        [StringLength(20, ErrorMessage = "Mobile phone cannot be longer than 20 characters.")]*/
        //Aspublic string MobilePhone { get; set; }
        /*[Display(Name = "Home Phone")]
        [StringLength(20, ErrorMessage = "Home phone cannot be longer than 20 characters.")]*/
        /*public string HomePhone { get; set; }
        [Display(Name = "Street 1")]
        [StringLength(20, ErrorMessage = "Street1 cannot be longer than 20 characters.")]
        public string Street1 { get; set; }*/
        /*[Display(Name = "Street 2")]
        [StringLength(20, ErrorMessage = "Street2 cannot be longer than 20 characters.")]
        public string Street2 { get; set; }
        [StringLength(20, ErrorMessage = "City cannot be longer than 20 characters.")]
        public string City { get; set; }
        [Display(Name = "State")]
        [StringLength(20, ErrorMessage = "State cannot be longer than 20 characters.")]
        public string Region { get; set; }
        [Display(Name = "Zip code")]
        [StringLength(20, ErrorMessage = "Zip code cannot be longer than 20 characters.")]
        public string Region2 { get; set; }
        [Display(Name = "Country")]
        public Nullable<int> CountryId { get; set; }
        [StringLength(20, ErrorMessage = "Postal code cannot be longer than 20 characters.")]
        public string PostalCode { get; set; }
        [StringLength(30, ErrorMessage = "Linkedin cannot be longer than 30 characters.")]
        public string Linkedin { get; set; }
        [StringLength(30, ErrorMessage = "Facebook cannot be longer than 30 characters.")]
        public string Facebook { get; set; }
        [StringLength(30, ErrorMessage = "Twitter cannot be longer than 30 characters.")]
        public string Twitter { get; set; }
        [Display(Name = "Role")]
        public Nullable<int> RoleId { get; set; }
        public bool Status { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastLogin { get; set; }*/
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