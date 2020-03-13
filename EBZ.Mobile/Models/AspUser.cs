using System;
using System.Collections.Generic;
using System.Text;

namespace EBZ.Mobile.Models
{
    public class AspUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CardId { get; set; }
        public string DepartmentName { get; set; }
        public string EmpNumber { get; set; }
        public string FirstName { get; set; }
        public string ImagePath { get; set; }
        public bool? IsEnabled { get; set; }
        public string LastName { get; set; }
        public string MealCategoryName { get; set; }
        public string SiteName { get; set; }
        public int? MealEntitledPerDay { get; set; }
    }
}
