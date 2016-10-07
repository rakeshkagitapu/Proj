namespace SPFS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SPFS_SPEND_SUPPLIERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SPFS_SPEND_SUPPLIERS()
        {
            SPFS_LINK_ERP = new HashSet<SPFS_LINK_ERP>();
            SPFS_STAGING_SUPPLIER_RATINGS = new HashSet<SPFS_STAGING_SUPPLIER_RATINGS>();
            SPFS_SUPPLIER_RATINGS = new HashSet<SPFS_SUPPLIER_RATINGS>();
        }

        [Key]
        public int Spend_supplier_ID { get; set; }

        public int SiteID { get; set; }

        public int SupplierID { get; set; }

        public decimal Total_Spend { get; set; }

        public int Reject_incident_count { get; set; }

        public int Reject_parts_count { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Created_date { get; set; }

        [StringLength(50)]
        public string Created_by { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Modified_date { get; set; }

        [StringLength(50)]
        public string Modified_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPFS_LINK_ERP> SPFS_LINK_ERP { get; set; }

        public virtual SPFS_SITES SPFS_SITES { get; set; }

        public virtual SPFS_SUPPLIERS SPFS_SUPPLIERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPFS_STAGING_SUPPLIER_RATINGS> SPFS_STAGING_SUPPLIER_RATINGS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPFS_SUPPLIER_RATINGS> SPFS_SUPPLIER_RATINGS { get; set; }
    }
}
