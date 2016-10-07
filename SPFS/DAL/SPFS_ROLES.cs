namespace SPFS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SPFS_ROLES
    {
        public SPFS_ROLES()
        {
            SPFS_USERS = new HashSet<SPFS_USERS>();
        }

        [Key]
        public int RoleID { get; set; }

        [StringLength(30)]
        public string RoleName { get; set; }

        public virtual ICollection<SPFS_USERS> SPFS_USERS { get; set; }
    }
}
