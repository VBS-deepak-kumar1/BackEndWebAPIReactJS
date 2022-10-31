using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BackEndWebAPIReactJS.Models;

#nullable disable

namespace BackEndWebAPIReactJS.Data
{
    public partial class AdventureWorks2017Context : DbContext
    {
        public AdventureWorks2017Context()
        {
        }

        public AdventureWorks2017Context(DbContextOptions<AdventureWorks2017Context> options)
            : base(options)
        {
        }
        public virtual DbSet<DeepakCustomer> DeepakCustomers { get; set; }
        public virtual DbSet<DeepakLandlord> DeepakLandlords { get; set; }
        public virtual DbSet<DeepakSite> DeepakSites { get; set; }
        public virtual DbSet<DeepakLkpAddress> DeepakLkpAddresses { get; set; }
        public virtual DbSet<DeepakLkpAssignedTo> DeepakLkpAssignedTos { get; set; }
        public virtual DbSet<DeepakLkpManager> DeepakLkpManagers { get; set; }
        public virtual DbSet<DeepakLkpSiteType> DeepakLkpSiteTypes { get; set; }
        public virtual DbSet<DeepakLkpStatus> DeepakLkpStatuses { get; set; }
        public virtual DbSet<DeepSiteAddress> DeepSiteAddresses { get; set; }




        // Unable to generate entity type for table 'Production.Document' since its primary key could not be scaffolded. Please see the warning messages.
        // Unable to generate entity type for table 'Production.ProductDocument' since its primary key could not be scaffolded. Please see the warning messages.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=192.168.1.230;Initial Catalog=AdventureWorks2017;Persist Security Info=True;User ID=trainee2022;Password=trainee@2022");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeepakCustomer>(entity =>
            {
                entity.HasKey(e => e.Customer_Id)
                    .HasName("PK__deepak_C__8CB286994D9BDD30");

                entity.ToTable("deepak_Customer");

                entity.Property(e => e.Customer_Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Customer_Id");

                entity.Property(e => e.Customer_Market)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Market");

                entity.Property(e => e.Customer_Region)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Region");

                entity.Property(e => e.Customer_Site)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Site");
            });

            modelBuilder.Entity<DeepakLandlord>(entity =>
            {
                entity.HasKey(e => e.Landlord_Id)
                    .HasName("PK__deepak_l__C9681E7EF2F7648D");

                entity.ToTable("deepak_landlord");

                entity.Property(e => e.Landlord_Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Landlord_Id");

                entity.Property(e => e.Cust_Id).HasColumnName("Cust_Id");

                entity.Property(e => e.Jurisdiction)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Landlord_ContactInfo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Landlord_ContactInfo");

                entity.Property(e => e.Landlord_Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Landlord_Name");

                entity.Property(e => e.Landlord_Type)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Landlord_Type");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.DeepakLandlords)
                    .HasForeignKey(d => d.Cust_Id)
                    .HasConstraintName("FK__deepak_la__Cust___6F6A7CB2");
            });

         

            modelBuilder.Entity<DeepakSite>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("deepak_Site");

                entity.Property(e => e.Ae_Firm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AE_Firm");

                entity.Property(e => e.Civil_Vendor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Civil_vendor");

                entity.Property(e => e.Construction_Vendor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Construction_Vendor");

                entity.Property(e => e.Cust_Id).HasColumnName("Cust_Id");

                entity.Property(e => e.End_Date)
                    .HasColumnType("date")
                    .HasColumnName("End_date");

                entity.Property(e => e.Field_Coordinator)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Field_Coordinator");

                entity.Property(e => e.Project_Manager)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Project_Manager");

                entity.Property(e => e.RealEstate_Specialist)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RealEstate_Specialist");

                entity.Property(e => e.SiteAcq_Vendor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SiteAcq_Vendor");

                entity.Property(e => e.Site_Id).HasColumnName("Site_Id");

                entity.Property(e => e.Site_Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Site_Name");

                entity.Property(e => e.Start_Date)
                    .HasColumnType("date")
                    .HasColumnName("Start_date");

                entity.HasOne(d => d.Cust)
                    .WithMany()
                    .HasForeignKey(d => d.Cust_Id)
                    .HasConstraintName("FK__deepak_Si__Cust___6C8E1007");
            });
            modelBuilder.Entity<DeepSiteAddress>(entity =>
            {
                entity.HasKey(e => e.ZipCode)
                    .HasName("PK__deep_sit__2CC2CDB94F37E817");

                entity.ToTable("deep_siteAddress");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustId).HasColumnName("Cust_Id");

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<DeepakLkpAddress>(entity =>
            {
                entity.HasKey(e => e.Zid)
                    .HasName("PK__deepak_l__D8FF637272FC57B1");

                entity.ToTable("deepak_lkpAddress");

                entity.Property(e => e.Zid)
                    .ValueGeneratedNever()
                    .HasColumnName("ZId");

                entity.Property(e => e.CustId).HasColumnName("Cust_Id");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.ZipCodeNavigation)
                    .WithMany(p => p.DeepakLkpAddresses)
                    .HasForeignKey(d => d.ZipCode)
                    .HasConstraintName("FK__deepak_lk__ZipCo__4A03EDD9");
            });
            modelBuilder.Entity<DeepakLkpAssignedTo>(entity =>
            {
                entity.HasKey(e => e.Aid)
                    .HasName("PK__deepak_l__C6900628E2CCBE25");

                entity.ToTable("deepak_lkpAssignedTo");

                entity.Property(e => e.Aid)
                    .ValueGeneratedNever()
                    .HasColumnName("AId");

                entity.Property(e => e.AssignedTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustId).HasColumnName("Cust_Id");
            });
            modelBuilder.Entity<DeepakLkpManager>(entity =>
            {
                entity.HasKey(e => e.AemanagerId)
                    .HasName("PK__deepak_l__61AB2A9449A33675");

                entity.ToTable("deepak_lkpManager");

                entity.Property(e => e.AemanagerId)
                    .ValueGeneratedNever()
                    .HasColumnName("AEManagerId");

                entity.Property(e => e.ClientCm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ClientCM");

                entity.Property(e => e.CustId).HasColumnName("Cust_Id");
            });
            modelBuilder.Entity<DeepakLkpSiteType>(entity =>
            {
                entity.HasKey(e => e.SiteTypeId)
                    .HasName("PK__deepak_l__8F0BFA542C5FFFBD");

                entity.ToTable("deepak_lkpSiteType");

                entity.Property(e => e.SiteTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("SiteType_Id");

                entity.Property(e => e.CustId).HasColumnName("Cust_Id");

                entity.Property(e => e.SiteType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<DeepakLkpStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__deepak_l__5190094CCF20481B");

                entity.ToTable("deepak_lkpStatus");

                entity.Property(e => e.StatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("Status_Id");

                entity.Property(e => e.CustId).HasColumnName("Cust_Id");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
            //modelBuilder.Entity<DeepakSiteAddress>(entity =>
            //{
            //    entity.HasKey(e => e.ZipCode)
            //        .HasName("PK__deepak_s__2CC2CDB96A098834");

            //    entity.ToTable("deepak_siteAddress");

            //    entity.Property(e => e.ZipCode)
            //        .HasMaxLength(6)
            //        .IsUnicode(false);

            //    entity.Property(e => e.City)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Country)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CustId).HasColumnName("Cust_Id");

            //    entity.Property(e => e.State)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Street)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);
            //});
            OnModelCreatingPartial(modelBuilder);         
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}







