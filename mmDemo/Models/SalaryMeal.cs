using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mmDemo.Models
{
    public class SalaryMeal
    {
        public int Id { get; set; }
        public string MealName { get; set; }
        public int MealType { get; set; }
        public decimal MealPrice { get; set; }
        public decimal MealCount { get; set; }
        public bool IsValid { get; set; }
        public decimal? DiscountRate { get; set; }

        public DateTime? DisBeginTime { get; set; }
        public DateTime? DisEndTime { get; set; }
    }
}