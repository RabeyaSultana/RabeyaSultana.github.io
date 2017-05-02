namespace HRManagementSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JobPosted")]
    public partial class JobPosted
    {
        [Key]
        public int JobId { get; set; }

        [StringLength(100)]
        public string JobDate { get; set; }

        [StringLength(100)]
        public string JobTitle { get; set; }

        [StringLength(20)]
        public string JobNature { get; set; }

        [StringLength(1000)]
        public string Descriptions { get; set; }

        [StringLength(20)]
        public string Vacancies { get; set; }

        [StringLength(100)]
        public string LastDateForApply { get; set; }

        [StringLength(100)]
        public string Location { get; set; }
    }
}
