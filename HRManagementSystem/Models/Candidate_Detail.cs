namespace HRManagementSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Candidate Details")]
    public partial class Candidate_Detail
    {


        [Key]
        public int cno { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]

        public string Dasignation { get; set; }

        [StringLength(50)]
        public string fatherName { get; set; }

        [StringLength(50)]
        public string motherName { get; set; }

        [StringLength(20)]
        public string email { get; set; }

        [StringLength(25)]
        public string mobNo { get; set; }

        public string dob { get; set; }

        [StringLength(20)]
        public string gender { get; set; }

        [StringLength(20)]
        public string nationality { get; set; }

        [StringLength(20)]
        public string NID { get; set; }

        [StringLength(20)]
        public string marritualStatus { get; set; }

        [StringLength(20)]
        public string religion { get; set; }

        [StringLength(20)]
        public string quota { get; set; }

        [StringLength(100)]
        public string TemAddress { get; set; }

        [StringLength(100)]
        public string ParAddress { get; set; }

        [StringLength(20)]
        public string examination { get; set; }

        [StringLength(20)]
        public string result { get; set; }

        [StringLength(70)]
        public string university { get; set; }

        [StringLength(10)]
        public string passingYear { get; set; }

        [StringLength(50)]
        public string groupSubject { get; set; }
        
        public string eImage { get; set; }


    }
}
