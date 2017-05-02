namespace HRManagementSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AttendenceDetails")]
    public partial class AttendenceDetail
    {


        [Key]
        [Column(Order = 0)]
        public int? empId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string aDate { get; set; }
        public string aTime { get; set; }


        public int Status { get; set; }

        public virtual EmployeeDetail EmployeeDetail { get; set; }
    }
}
