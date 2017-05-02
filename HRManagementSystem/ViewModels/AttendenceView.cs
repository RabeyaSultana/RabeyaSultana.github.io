using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRManagementSystem.ViewModels
{
    public class AttendenceView
    {
        public int empId { get; set; }

        [StringLength(50)]
        public string eName { get; set; }

        [StringLength(50)]
        public string eDesignation { get; set; }

        public string aDate { get; set; }
        public string aTime { get; set; }

      
        public int Status { get; set; }

    }
}