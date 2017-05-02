namespace HRManagementSystem
{
    using HRManagementSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmployeeDetail
    {
        public EmployeeDetail()
        {
            AttendenceDetails = new HashSet<AttendenceDetail>();
            SalaryDetails = new HashSet<SalaryDetail>();
            
        }

        [Key]
        public int empId { get; set; }

        [StringLength(50)]
        public string eName { get; set; }

        [StringLength(10)]
        public string eGender { get; set; }

        [Column(TypeName = "date")]
        public DateTime? eDOB { get; set; }

        [StringLength(20)]
        public string MarritualStatus { get; set; }

        public string ePresentAddress { get; set; }

        public string ePermanentAddress { get; set; }

        [StringLength(10)]
        public string eBloodGroup { get; set; }

        [StringLength(20)]
        public string eMobile { get; set; }

        [StringLength(30)]
        public string eEmail { get; set; }

        [StringLength(30)]
        public string eNationality { get; set; }

        [StringLength(20)]
        public string eNID { get; set; }

        [StringLength(30)]
        public string eReligion { get; set; }

        [StringLength(50)]
        public string eDesignation { get; set; }

        [Column(TypeName = "date")]
        public DateTime? eDOJ { get; set; }

        [Column(TypeName = "money")]
        public decimal? BasicPay { get; set; }

        public string eQualification { get; set; }

        public string eExperience { get; set; }

        [StringLength(50)]
        public string eContactPerson { get; set; }

        [StringLength(10)]
        public string eLoan { get; set; }

        public string eLoanDescription { get; set; }

        [StringLength(10)]
        public string eExteaCurriculam { get; set; }

        public string eExteaCurriculamDescription { get; set; }

        public string eImage { get; set; }

        public virtual ICollection<AttendenceDetail> AttendenceDetails { get; set; }

        public virtual ICollection<SalaryDetail> SalaryDetails { get; set; }

    }
}
