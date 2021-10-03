using System;
using System.Collections.Generic;
using System.Text;

namespace ILG_CRUD_Sample.DataAccess.Models
{
    public class EmployeeTask
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string Title { get; set; }
        public int Description { get; set; }
    }
}
