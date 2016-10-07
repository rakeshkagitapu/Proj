namespace SPFS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SPFS_USERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SPFS_USERS()
        {
            SPFS_STAGING_SUPPLIER_RATINGS = new HashSet<SPFS_STAGING_SUPPLIER_RATINGS>();
            SPFS_SUPPLIER_RATINGS = new HashSet<SPFS_SUPPLIER_RATINGS>();
            SPFS_USERSITES = new HashSet<SPFS_USERSITES>();
        }

        [Key]
        public int UserID { get; set; }

        public int RoleID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(10)]
        public string SPFS_Active { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Active_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Created_date { get; set; }

        [StringLength(50)]
        public string Created_by { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Modified_date { get; set; }

        [StringLength(50)]
        public string Modified_by { get; set; }

        public virtual SPFS_ROLES SPFS_ROLES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPFS_STAGING_SUPPLIER_RATINGS> SPFS_STAGING_SUPPLIER_RATINGS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPFS_SUPPLIER_RATINGS> SPFS_SUPPLIER_RATINGS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPFS_USERSITES> SPFS_USERSITES { get; set; }
    }
}
