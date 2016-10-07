namespace SPFS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SPFS_SUPPLIERS
    {
        public SPFS_SUPPLIERS()
        {
            SPFS_SPEND_SUPPLIERS = new HashSet<SPFS_SPEND_SUPPLIERS>();
            SPFS_STAGING_SUPPLIER_RATINGS = new HashSet<SPFS_STAGING_SUPPLIER_RATINGS>();
            SPFS_SUPPLIER_RATINGS = new HashSet<SPFS_SUPPLIER_RATINGS>();
        }

        [Key]
        public int SupplierID { get; set; }

        public int Cid { get; set; }

        [Required]
        [StringLength(10)]
        public string Duns { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Address_1 { get; set; }

        [StringLength(50)]
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

        public virtual ICollection<SPFS_SPEND_SUPPLIERS> SPFS_SPEND_SUPPLIERS { get; set; }

        public virtual ICollection<SPFS_STAGING_SUPPLIER_RATINGS> SPFS_STAGING_SUPPLIER_RATINGS { get; set; }

        public virtual ICollection<SPFS_SUPPLIER_RATINGS> SPFS_SUPPLIER_RATINGS { get; set; }
    }
}
