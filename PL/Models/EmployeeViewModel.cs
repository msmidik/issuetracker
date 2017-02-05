using BL.DTOs;
using System.Collections.Generic;

namespace PL.Models
{
    public class EmployeeViewModel
    {
        public List<EmployeeDTO> Employees { get; set; }
        public EmployeeViewModel()
        {
            Employees = new List<EmployeeDTO>();
        }
    }
}