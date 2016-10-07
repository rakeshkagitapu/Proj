namespace SPFS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SPFS_SUPPLIER_RATINGS
    {
        [Key]
        public int RatingsID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Rating_period { get; set; }

        public int SiteID { get; set; }

        public int SupplierID { get; set; }

        public int Spend_supplier_ID { get; set; }

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

        public bool? Interface_flag { get; set; }

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
