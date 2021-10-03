using System;
using System.Collections.Generic;
using System.Text;

namespace ILG_CRUD_Sample.BusinessLogic.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
