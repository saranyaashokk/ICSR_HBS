namespace DataLayer.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HBDataModel : DbContext
    {
        public HBDataModel()
            : base("name=HBDataModel")
        {
        }

        public virtual DbSet<tbl_booking_users> tbl_booking_users { get; set; }
        public virtual DbSet<tbl_collaborative> tbl_collaborative { get; set; }
        public virtual DbSet<tbl_dining_halls> tbl_dining_halls { get; set; }
        public virtual DbSet<tbl_event_manager> tbl_event_manager { get; set; }
        public virtual DbSet<tbl_faculty_IIT> tbl_faculty_IIT { get; set; }
        public virtual DbSet<tbl_halls> tbl_halls { get; set; }
        public virtual DbSet<tbl_mst_approval_status> tbl_mst_approval_status { get; set; }
        public virtual DbSet<tbl_mst_dept_IIT> tbl_mst_dept_IIT { get; set; }
        public virtual DbSet<tbl_mst_designation_IIT> tbl_mst_designation_IIT { get; set; }
        public virtual DbSet<tbl_mst_diningHall_slot> tbl_mst_diningHall_slot { get; set; }
        public virtual DbSet<tbl_mst_hallStatus> tbl_mst_hallStatus { get; set; }
        public virtual DbSet<tbl_mst_mode_of_payment> tbl_mst_mode_of_payment { get; set; }
        public virtual DbSet<tbl_mst_reservation_type> tbl_mst_reservation_type { get; set; }
        public virtual DbSet<tbl_payment> tbl_payment { get; set; }
        public virtual DbSet<tbl_receipt> tbl_receipt { get; set; }
        public virtual DbSet<tbl_trx_booking_timeSlot> tbl_trx_booking_timeSlot { get; set; }
        public virtual DbSet<tbl_trx_email_log> tbl_trx_email_log { get; set; }
        public virtual DbSet<tbl_trx_reservation> tbl_trx_reservation { get; set; }
        public virtual DbSet<tbl_users_ICSR> tbl_users_ICSR { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_booking_users>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_booking_users>()
                .Property(e => e.tele_no)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_collaborative>()
                .Property(e => e.tele_no)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_faculty_IIT>()
                .Property(e => e.facultyName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_faculty_IIT>()
                .Property(e => e.tele_no)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_halls>()
                .HasMany(e => e.tbl_trx_booking_timeSlot)
                .WithRequired(e => e.tbl_halls)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_halls>()
                .HasMany(e => e.tbl_trx_reservation)
                .WithRequired(e => e.tbl_halls)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_mst_approval_status>()
                .HasMany(e => e.tbl_trx_booking_timeSlot)
                .WithRequired(e => e.tbl_mst_approval_status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_mst_approval_status>()
                .HasMany(e => e.tbl_trx_reservation)
                .WithRequired(e => e.tbl_mst_approval_status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_mst_dept_IIT>()
                .Property(e => e.deptName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_mst_dept_IIT>()
                .Property(e => e.deptCode)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_mst_dept_IIT>()
                .HasMany(e => e.tbl_booking_users)
                .WithRequired(e => e.tbl_mst_dept_IIT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_mst_dept_IIT>()
                .HasMany(e => e.tbl_collaborative)
                .WithRequired(e => e.tbl_mst_dept_IIT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_mst_dept_IIT>()
                .HasMany(e => e.tbl_faculty_IIT)
                .WithRequired(e => e.tbl_mst_dept_IIT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_mst_designation_IIT>()
                .Property(e => e.designation)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_mst_designation_IIT>()
                .Property(e => e.designation_code)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_mst_diningHall_slot>()
                .Property(e => e.dining_slot_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_mst_hallStatus>()
                .Property(e => e.hallStatus)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_mst_hallStatus>()
                .HasMany(e => e.tbl_dining_halls)
                .WithRequired(e => e.tbl_mst_hallStatus)
                .HasForeignKey(e => e.hallStatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_mst_hallStatus>()
                .HasMany(e => e.tbl_halls)
                .WithRequired(e => e.tbl_mst_hallStatus)
                .HasForeignKey(e => e.hallStatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_mst_mode_of_payment>()
                .Property(e => e.mode_of_payment)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_mst_mode_of_payment>()
                .HasMany(e => e.tbl_payment)
                .WithRequired(e => e.tbl_mst_mode_of_payment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_mst_reservation_type>()
                .HasMany(e => e.tbl_trx_reservation)
                .WithRequired(e => e.tbl_mst_reservation_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_payment>()
                .Property(e => e.cheque_no_dd_no)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_payment>()
                .Property(e => e.faculty_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_payment>()
                .Property(e => e.department)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_payment>()
                .Property(e => e.amount_in_words)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_payment>()
                .HasMany(e => e.tbl_receipt)
                .WithRequired(e => e.tbl_payment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_trx_reservation>()
                .Property(e => e.reservation_amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_trx_reservation>()
                .HasMany(e => e.tbl_collaborative)
                .WithRequired(e => e.tbl_trx_reservation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_trx_reservation>()
                .HasMany(e => e.tbl_event_manager)
                .WithRequired(e => e.tbl_trx_reservation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_trx_reservation>()
                .HasMany(e => e.tbl_faculty_IIT)
                .WithRequired(e => e.tbl_trx_reservation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_trx_reservation>()
                .HasMany(e => e.tbl_payment)
                .WithRequired(e => e.tbl_trx_reservation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_trx_reservation>()
                .HasMany(e => e.tbl_trx_booking_timeSlot)
                .WithRequired(e => e.tbl_trx_reservation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_trx_reservation>()
                .HasMany(e => e.tbl_trx_email_log)
                .WithRequired(e => e.tbl_trx_reservation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_trx_reservation>()
                .HasOptional(e => e.tbl_trx_reservation1)
                .WithRequired(e => e.tbl_trx_reservation2);

            modelBuilder.Entity<tbl_users_ICSR>()
                .Property(e => e.full_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_users_ICSR>()
                .Property(e => e.designation)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_users_ICSR>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_users_ICSR>()
                .Property(e => e.passWord)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_users_ICSR>()
                .HasMany(e => e.tbl_trx_reservation)
                .WithOptional(e => e.tbl_users_ICSR)
                .HasForeignKey(e => e.approvedBy);
        }
    }
}
