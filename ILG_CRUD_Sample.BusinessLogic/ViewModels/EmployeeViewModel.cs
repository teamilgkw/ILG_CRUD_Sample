using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILG_CRUD_Sample.BusinessLogic.ViewModels
{
    public class EmployeeViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int Age { get; set; }
        public DateTime BirthDate { get; set; }

        
    }
}
