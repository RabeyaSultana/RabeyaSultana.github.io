namespace HRManagementSystem
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HRMSContext : DbContext
    {
        public HRMSContext()
            : base("name=HRMSContext")
        {
        }

    
        public virtual DbSet<AttendenceDetail> AttendenceDetails { get; set; }
        public virtual DbSet<Candidate_Detail> Candidate_Details { get; set; }
        public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public virtual DbSet<EmployeeLogin> EmployeeLogins { get; set; }
        public virtual DbSet<JobPosted> JobPosteds { get; set; }
        public virtual DbSet<SalaryDetail> SalaryDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {



            //modelBuilder.Entity<AttendenceDetail>()
            //    .Property(e => e.Status)
            //    .IsUnicode(false);

            modelBuilder.Entity<Candidate_Detail>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate_Detail>()
                .Property(e => e.fatherName)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate_Detail>()
                .Property(e => e.motherName)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate_Detail>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate_Detail>()
                .Property(e => e.mobNo)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate_Detail>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate_Detail>()
                .Property(e => e.nationality)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate_Detail>()
                .Property(e => e.NID)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate_Detail>()
                .Property(e => e.marritualStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate_Detail>()
                .Property(e => e.religion)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate_Detail>()
                .Property(e => e.quota)
                .IsUnicode(false);


            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.eName)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.eGender)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.MarritualStatus)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.ePresentAddress)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.ePermanentAddress)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.eBloodGroup)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.eMobile)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.eEmail)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.eNationality)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.eNID)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.eReligion)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.eDesignation)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.eQualification)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.eExperience)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.eContactPerson)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.eLoan)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.eLoanDescription)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.eExteaCurriculam)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.eExteaCurriculamDescription)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.eImage)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeLogin>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeLogin>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeLogin>()
                .Property(e => e.UserPassword)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeLogin>()
                .Property(e => e.UserRole)
                .IsUnicode(false);

            modelBuilder.Entity<JobPosted>()
                .Property(e => e.JobTitle)
                .IsUnicode(false);

            modelBuilder.Entity<JobPosted>()
                .Property(e => e.Descriptions)
                .IsUnicode(false);

            modelBuilder.Entity<JobPosted>()
                .Property(e => e.Vacancies)
                .IsUnicode(false);

            modelBuilder.Entity<JobPosted>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<SalaryDetail>()
                .Property(e => e.HRA)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalaryDetail>()
                .Property(e => e.MedicalAllowance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalaryDetail>()
                .Property(e => e.Convayence)
                .HasPrecision(19, 4);

                       
            modelBuilder.Entity<SalaryDetail>()
                .Property(e => e.ProvidentFund)
                .HasPrecision(19, 4);

           
            

            modelBuilder.Entity<SalaryDetail>()
                .Property(e => e.Tax)
                .HasPrecision(19, 4);

           

            modelBuilder.Entity<SalaryDetail>()
                .Property(e => e.TotalEarnings)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalaryDetail>()
                .Property(e => e.TotalDeduction)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalaryDetail>()
                .Property(e => e.NetPay)
                .HasPrecision(19, 4);
        }

    }
}
