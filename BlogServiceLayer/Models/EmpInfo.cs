using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogServiceLayer.Models
{
    public class EmpInfoModel
    {
        public int EmpInfoId { get; set; }
        public string EmailId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string PassCode { get; set; }
    }
}