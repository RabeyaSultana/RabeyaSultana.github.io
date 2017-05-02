namespace HRManagementSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeLogin")]
    public partial class EmployeeLogin
    {
        [Key]
        [Required]
        public int loginId { get; set; }

        [StringLength(30)]
        [Index(IsUnique=true)]
        [Required]
        public string Email { get; set; }
        [Required]

        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        [StringLength(25)]
        public string UserPassword { get; set; }
        [Required]
        [StringLength(20)]
        public string UserRole { get; set; }
    }
}
