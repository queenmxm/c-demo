using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mmDemo.Models
{
    public class MMContext:DbContext
    {
        public MMContext():base("MMContext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SalaryMealMap());
        }
    }
}