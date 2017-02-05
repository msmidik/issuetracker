using BL.DTOs;
using System.Collections.Generic;

namespace PL.Models
{
    public class CustomerViewModel
    {
        public List<CustomerDTO> Customers { get; set; }
        public CustomerViewModel()
        {
            Customers = new List<CustomerDTO>();
        }
    }
}