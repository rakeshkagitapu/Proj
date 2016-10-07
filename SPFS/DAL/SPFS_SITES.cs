namespace SPFS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SPFS_SITES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SPFS_SITES()
        {
            SPFS_SPEND_SUPPLIERS = new HashSet<SPFS_SPEND_SUPPLIERS>();
            SPFS_STAGING_SUPPLIER_RATINGS = new HashSet<SPFS_STAGING_SUPPLIER_RATINGS>();
            SPFS_SUPPLIER_RATINGS = new HashSet<SPFS_SUPPLIER_RATINGS>();
            SPFS_USERSITES = new HashSet<SPFS_USERSITES>();
        }

        [Key]
        public int SiteID { get; set; }

        public int Gdis_org_entity_id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string Address_1 { get; set; }

        public string Address_2 { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string ContactNum { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPFS_SPEND_SUPPLIERS> SPFS_SPEND_SUPPLIERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPFS_STAGING_SUPPLIER_RATINGS> SPFS_STAGING_SUPPLIER_RATINGS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPFS_SUPPLIER_RATINGS> SPFS_SUPPLIER_RATINGS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPFS_USERSITES> SPFS_USERSITES { get; set; }
    }
}
