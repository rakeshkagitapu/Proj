namespace SPFS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SPFS_USERSITES
    {
        [Key]
        public int UserSitesID { get; set; }

        public int UserID { get; set; }

        public int SiteID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Created_date { get; set; }

        [StringLength(50)]
        public string Created_by { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Modified_date { get; set; }

        [StringLength(50)]
        public string Modified_by { get; set; }

        public virtual SPFS_SITES SPFS_SITES { get; set; }

        public virtual SPFS_USERS SPFS_USERS { get; set; }
    }
}
