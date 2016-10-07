namespace SPFS.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SPFSContext : DbContext
    {
        public SPFSContext()
            : base("name=SPFSContext1")
        {
        }

        public virtual DbSet<SPFS_LINK_ERP> SPFS_LINK_ERP { get; set; }
        public virtual DbSet<SPFS_ROLES> SPFS_ROLES { get; set; }
        public virtual DbSet<SPFS_SITES> SPFS_SITES { get; set; }
        public virtual DbSet<SPFS_SPEND_SUPPLIERS> SPFS_SPEND_SUPPLIERS { get; set; }
        public virtual DbSet<SPFS_STAGING_SUPPLIER_RATINGS> SPFS_STAGING_SUPPLIER_RATINGS { get; set; }
        public virtual DbSet<SPFS_SUPPLIER_RATINGS> SPFS_SUPPLIER_RATINGS { get; set; }
        public virtual DbSet<SPFS_SUPPLIERS> SPFS_SUPPLIERS { get; set; }
        public virtual DbSet<SPFS_USERS> SPFS_USERS { get; set; }
        public virtual DbSet<SPFS_USERSITES> SPFS_USERSITES { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SPFS_ROLES>()
                .Property(e => e.RoleName)
                .IsFixedLength();

            modelBuilder.Entity<SPFS_ROLES>()
                .HasMany(e => e.SPFS_USERS)
                .WithRequired(e => e.SPFS_ROLES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SPFS_SITES>()
                .HasMany(e => e.SPFS_SPEND_SUPPLIERS)
                .WithRequired(e => e.SPFS_SITES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SPFS_SITES>()
                .HasMany(e => e.SPFS_STAGING_SUPPLIER_RATINGS)
                .WithRequired(e => e.SPFS_SITES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SPFS_SITES>()
                .HasMany(e => e.SPFS_SUPPLIER_RATINGS)
                .WithRequired(e => e.SPFS_SITES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SPFS_SITES>()
                .HasMany(e => e.SPFS_USERSITES)
                .WithRequired(e => e.SPFS_SITES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SPFS_SPEND_SUPPLIERS>()
                .Property(e => e.Total_Spend)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SPFS_SPEND_SUPPLIERS>()
                .HasMany(e => e.SPFS_LINK_ERP)
                .WithRequired(e => e.SPFS_SPEND_SUPPLIERS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SPFS_SPEND_SUPPLIERS>()
                .HasMany(e => e.SPFS_STAGING_SUPPLIER_RATINGS)
                .WithRequired(e => e.SPFS_SPEND_SUPPLIERS)
                .HasForeignKey(e => e.Spend_supplierID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SPFS_SPEND_SUPPLIERS>()
                .HasMany(e => e.SPFS_SUPPLIER_RATINGS)
                .WithRequired(e => e.SPFS_SPEND_SUPPLIERS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SPFS_STAGING_SUPPLIER_RATINGS>()
                .Property(e => e.Inbound_parts)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SPFS_STAGING_SUPPLIER_RATINGS>()
                .Property(e => e.OTR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SPFS_STAGING_SUPPLIER_RATINGS>()
                .Property(e => e.OTD)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SPFS_STAGING_SUPPLIER_RATINGS>()
                .Property(e => e.PFR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SPFS_SUPPLIER_RATINGS>()
                .Property(e => e.Inbound_parts)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SPFS_SUPPLIER_RATINGS>()
                .Property(e => e.OTR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SPFS_SUPPLIER_RATINGS>()
                .Property(e => e.OTD)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SPFS_SUPPLIER_RATINGS>()
                .Property(e => e.PFR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SPFS_SUPPLIERS>()
                .Property(e => e.Duns)
                .IsFixedLength();

            modelBuilder.Entity<SPFS_SUPPLIERS>()
                .HasMany(e => e.SPFS_SPEND_SUPPLIERS)
                .WithRequired(e => e.SPFS_SUPPLIERS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SPFS_SUPPLIERS>()
                .HasMany(e => e.SPFS_STAGING_SUPPLIER_RATINGS)
                .WithRequired(e => e.SPFS_SUPPLIERS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SPFS_SUPPLIERS>()
                .HasMany(e => e.SPFS_SUPPLIER_RATINGS)
                .WithRequired(e => e.SPFS_SUPPLIERS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SPFS_USERS>()
                .HasMany(e => e.SPFS_STAGING_SUPPLIER_RATINGS)
                .WithRequired(e => e.SPFS_USERS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SPFS_USERS>()
                .HasMany(e => e.SPFS_SUPPLIER_RATINGS)
                .WithRequired(e => e.SPFS_USERS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SPFS_USERS>()
                .HasMany(e => e.SPFS_USERSITES)
                .WithRequired(e => e.SPFS_USERS)
                .WillCascadeOnDelete(false);
        }
    }
}
