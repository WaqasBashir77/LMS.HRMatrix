using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using LMS.HRMatrix.Model;


namespace LMS.HRMatrix.Data.Configuration
{
    class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("Employees");
            Property(g => g.Salutation).IsOptional().HasMaxLength(50);
            Property(g => g.FirstName).IsRequired().HasMaxLength(75);
            Property(g => g.MiddleName).IsOptional().HasMaxLength(50);
            Property(g => g.LastName).IsRequired().HasMaxLength(75);
            Property(g => g.NickName).IsOptional().HasMaxLength(50);
            Property(g => g.DisplayName).IsOptional().HasMaxLength(50);
            Property(g => g.PersonNumber).IsOptional().HasMaxLength(20);
            Property(g => g.WorkEmail).IsRequired().HasMaxLength(50);
            /*Property(g => g.LocationId).IsOptional();
            Property(g => g.DivisionId).IsOptional();
            Property(g => g.DepartmentId).IsOptional();
            Property(g => g.JobTitleId).IsOptional();
            Property(g => g.ReportsToId).IsOptional();
            Property(g => g.EmploymentStatusId).IsOptional();
            Property(g => g.HomeEmail).IsOptional().HasMaxLength(50);
            Property(g => g.SSNumber).IsOptional().HasMaxLength(20);
            Property(g => g.SINumber).IsOptional().HasMaxLength(20);
            Property(g => g.NINumber).IsOptional().HasMaxLength(20);
            Property(g => g.TaxFileNumber).IsOptional().HasMaxLength(20);
            Property(g => g.BloodGroup).IsOptional().HasMaxLength(10);
            Property(g => g.Gender).HasMaxLength(20).IsOptional(); 
            Property(g => g.MaritalStatusId).IsOptional();
            Property(g => g.DateOfBirth).IsOptional();
            Property(g => g.EthnicityId).IsOptional();
            Property(g => g.EEOJobCategoryId).IsOptional();
            Property(g => g.NationalityId).IsOptional();
            Property(g => g.VeteranStatus).IsOptional();
            Property(g => g.HireDate).IsOptional();
            Property(g => g.TerminationDate).IsOptional();
            Property(g => g.WorkPhone).IsOptional().HasMaxLength(20);
            Property(g => g.WorkExt).IsOptional().HasMaxLength(20);
            Property(g => g.MobilePhone).IsOptional().HasMaxLength(20);
            Property(g => g.HomePhone).IsOptional().HasMaxLength(20);
            Property(g => g.Street1).IsOptional().HasMaxLength(20);
            Property(g => g.Street2).IsOptional().HasMaxLength(20);
            Property(g => g.City).IsOptional().HasMaxLength(20);
            Property(g => g.Region).IsOptional().HasMaxLength(20);
            Property(g => g.Region2).IsOptional().HasMaxLength(20);
            Property(g => g.Linkedin).IsOptional().HasMaxLength(30);
            Property(g => g.Facebook).IsOptional().HasMaxLength(30);
            Property(g => g.Twitter).IsOptional().HasMaxLength(30);
            Property(g => g.CountryId).IsOptional();
            Property(g => g.PostalCode).IsOptional().HasMaxLength(20);
            Property(g => g.CreationDate).IsRequired();
            Property(g => g.LastUpdateDate).IsRequired();
            Property(g => g.Status).IsOptional();*/
        }
    }
}
