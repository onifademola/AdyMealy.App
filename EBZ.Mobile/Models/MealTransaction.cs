using System;
using System.Collections.Generic;
using System.Text;

namespace EBZ.Mobile.Models
{
    public class MealTransaction
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime MealTime { get; set; }
        public DateTime? QueueTime { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string CardId { get; set; }
        public string DepartmentName { get; set; }
        public string EmpNumber { get; set; }
        public int? MealEntitledPerDay { get; set; }
    }
}
