//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//#nullable disable

//namespace BackEndWebAPIReactJS.Models
//{
//    public partial class AdventureWorks2017Context : DbContext
//    {
//        public AdventureWorks2017Context()
//        {
//        }

//        public AdventureWorks2017Context(DbContextOptions<AdventureWorks2017Context> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<DeepSiteAddress> DeepSiteAddresses { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=192.168.1.230;Initial Catalog=AdventureWorks2017;Persist Security Info=True;User ID=trainee2022;Password=trainee@2022");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<DeepSiteAddress>(entity =>
//            {
//                entity.HasKey(e => e.ZipCode)
//                    .HasName("PK__deep_sit__2CC2CDB94F37E817");

//                entity.ToTable("deep_siteAddress");

//                entity.Property(e => e.ZipCode)
//                    .HasMaxLength(6)
//                    .IsUnicode(false);

//                entity.Property(e => e.Country)
//                    .HasMaxLength(20)
//                    .IsUnicode(false);

//                entity.Property(e => e.CustId).HasColumnName("Cust_Id");

//                entity.Property(e => e.State)
//                    .HasMaxLength(20)
//                    .IsUnicode(false);

//                entity.Property(e => e.Street)
//                    .HasMaxLength(20)
//                    .IsUnicode(false);
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}
