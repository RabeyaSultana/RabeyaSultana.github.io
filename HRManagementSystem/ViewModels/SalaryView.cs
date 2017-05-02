using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRManagementSystem.Models
{
    public class SalaryView
    {
        public int empId { get; set; }

        [StringLength(50)]
        public string eName { get; set; }
        [StringLength(50)]
        public string eDesignation { get; set; }

        [Column(TypeName = "money")]
        public decimal? BasicPay { get; set; }

        public decimal? TotalEarnings { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalDeduction { get; set; }

        [Column(TypeName = "money")]
        public decimal? NetPay { get; set; }

    }
}