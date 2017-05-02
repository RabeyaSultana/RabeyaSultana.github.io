using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRManagementSystem.ViewModels
{
    public class EmployeeView
    {

        public int empId { get; set; }

        [StringLength(50)]
        public string eName { get; set; }

        [StringLength(50)]
        public string eDesignation { get; set; }

        [StringLength(20)]
        public string eMobile { get; set; }

        [StringLength(30)]
        public string eEmail { get; set; }

        public int Status { get; set; }

        [Column(TypeName = "money")]
        public decimal? BasicPay { get; set; }

        [Column(TypeName = "money")]
        public decimal? NetPay { get; set; }

    }
}