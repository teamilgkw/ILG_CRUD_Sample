using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ILG_CRUD_Sample.BusinessLogic.ViewModels
{
    public class EmployeeSearchViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Display(Name = "Age")]
        //public string Age { get; set; }

        [Display(Name = "Age From")]
        public int? AgeFrom { get; set; }

        [Display(Name = "Age To")]
        public int? AgeTo { get; set; }

        //[Display(Name = "BirthDate")]
        //public string BirthDate { get; set; }

        [Display(Name = "Birth Date From")]
        public DateTime? BirthDateFrom { get; set; }

        [Display(Name = "Birth Date To")]
        public DateTime? BirthDateTo { get; set; }


        public IEnumerable<EmployeeViewModel> SearchResult { get; set; }

    }
}
