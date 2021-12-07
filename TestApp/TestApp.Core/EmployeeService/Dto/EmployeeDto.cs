using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Data.Enums;

namespace TestApp.Core.EmployeeService.Dto
{
    public class EmployeeDto
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Display(Name = "Salary")]
        public decimal Salary { get; set; }

        [Display(Name = "Designation")]
        public string Designation { get; set; }
    }
}
