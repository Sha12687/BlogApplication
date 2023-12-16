using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppUILayer.Models.ViewModel
{
    public class EmployeeRegisterModel
    {
        public string EmailId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfJoining { get; set; } = DateTime.Now;
    }
}