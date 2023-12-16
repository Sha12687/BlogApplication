using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppUILayer.Models.ViewModel
{
    public class BlogViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string BlogUrl { get; set; }
        public string EmployeeName { get; set; }
    }
}