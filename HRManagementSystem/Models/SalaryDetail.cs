namespace HRManagementSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SalaryDetail
    {
        [Key]
        public int SalaryId { get; set; }
  
        public string sDate { get; set; }

        public int? empId { get; set; }

        [Column(TypeName = "money")]
        public decimal? HRA { get; set; }

        [Column(TypeName = "money")]
        public decimal? MedicalAllowance { get; set; }

        [Column(TypeName = "money")]
        public decimal? Convayence { get; set; }
       
        [Column(TypeName = "money")]
        public decimal? ProvidentFund { get; set; }

        [Column(TypeName = "money")]
     
        public decimal? Tax { get; set; }        
        [Column(TypeName = "money")]
        public decimal? TotalEarnings { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalDeduction { get; set; }

        [Column(TypeName = "money")]
        public decimal? NetPay { get; set; }

        public virtual EmployeeDetail EmployeeDetail { get; set; }
    }
}
