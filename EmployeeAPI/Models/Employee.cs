using EmployeeAPI.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Models
{
    public class Employee
    {
        #region Properties
        [Required(ErrorMessage = "IdRequired")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "NameRequired")]
        [StringLength(64, MinimumLength = 2)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "SurNameRequierd")]
        [StringLength(64, MinimumLength = 2)]
        [Display(Name = "SurName")]
        public string SurName { get; set; }

        [StringLength(64, MinimumLength = 2)]
        [Display(Name = "Patronymic")]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "DateRequired")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime RegistrationDate { get; set; }

        [StringLength(256, MinimumLength = 2)]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Phone]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public User Identity { get; set; }
        #endregion  
    }
}
