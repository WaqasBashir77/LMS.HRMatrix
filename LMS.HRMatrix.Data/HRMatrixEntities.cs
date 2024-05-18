using LMS.HRMatrix.Data.Configuration;
using LMS.HRMatrix.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace LMS.HRMatrix.Data
{
    public class HRMatrixEntities : DbContext
    {
        public HRMatrixEntities() : base("HRMatrixEntities") { }

        public DbSet<Employee> Employee { get; set; }
        

        public DbSet<CustomFields> CustomFields { get; set; }

        public DbSet<CustomFieldKey> CustomFieldKeys { get; set; }

        public DbSet<CustomFieldKeyValue> CustomFieldKeyValues { get; set; }
        /*
        public DbSet<CustomFormModel> CustomFormModel { get; set; }
        public DbSet<CustomFieldModel> CustomFieldModel { get; set; }
       */

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
        }
    }
}
