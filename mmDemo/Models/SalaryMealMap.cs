using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
namespace mmDemo.Models
{
    public class SalaryMealMap : EntityTypeConfiguration<SalaryMeal>
    {
        public SalaryMealMap()
        {
            this.ToTable("SalaryMeal");
            this.Property(p => p.Id).HasColumnName("Id");
            this.Property(p => p.MealName).HasColumnName("MealName");
            this.Property(p => p.MealType).HasColumnName("MealType");
            this.Property(p => p.MealPrice).HasColumnName("MealPrice");
            this.Property(p => p.MealCount).HasColumnName("MealCount");
            this.Property(p => p.IsValid).HasColumnName("IsValid");
            this.Property(p => p.DiscountRate).HasColumnName("DiscountRate");
            this.Property(p => p.DisBeginTime).HasColumnName("DisBeginTime");
            this.Property(p => p.DisEndTime).HasColumnName("DisEndTime");
           
        }
    }
}
