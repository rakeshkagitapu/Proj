namespace SPFS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SPFS_STAGING_SUPPLIER_RATINGS
    {
        [Key]
        public int StagingID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Rating_period { get; set; }

        public int SiteID { get; set; }

        public int SupplierID { get; set; }

        public int Spend_supplierID { get; set; }

        public int Gdis_org_entity { get; set; }

        public int duns { get; set; }

        public int cid { get; set; }

        public int Erp_supplier_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Inbound_parts { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OTR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OTD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PFR { get; set; }

        [Column(TypeName = "date")]
        public DateTime Initial_submission_date { get; set; }

        [Column("Temp_Upload?")]
        public bool? Temp_Upload_ { get; set; }

        public int UserID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Created_date { get; set; }

        [StringLength(50)]
        public string Created_by { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Modified_date { get; set; }

        [StringLength(50)]
        public string Modified_by { get; set; }

        public virtual SPFS_SITES SPFS_SITES { get; set; }

        public virtual SPFS_SPEND_SUPPLIERS SPFS_SPEND_SUPPLIERS { get; set; }

        public virtual SPFS_SUPPLIERS SPFS_SUPPLIERS { get; set; }

        public virtual SPFS_USERS SPFS_USERS { get; set; }
    }
}
