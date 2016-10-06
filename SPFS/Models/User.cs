
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SPFS.Models
{
    /// <summary>
    /// Class User.
    /// </summary>
    public class User 
    {

        /// </summary>
        /// <value>The user identifier.</value>
        [Required]
        public int UserID { get; set; }
               /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        [Required]
        [Display(Name="User Name")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>The department identifier.</value>
        //[Required]
        //[Display(Name = "Department")]
        //public int? DepartmentID { get; set; }
        ///// <summary>
        ///// Gets or sets the department.
        ///// </summary>
        ///// <value>The department.</value>
        //public virtual Department Department { get; set; }

        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>The location identifier.</value>
        //[Required]
        //[Display(Name = "Location")]
        //public int? LocationID { get; set; }
        ///// <summary>
        ///// Gets or sets the location.
        ///// </summary>
        ///// <value>The location.</value>
        //public virtual Location Location { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>The role identifier.</value>
        //[Required]
        //[Display(Name = "Role")]
        //public int? RoleID { get; set; }
        ///// <summary>
        ///// Gets or sets the role.
        ///// </summary>
        ///// <value>The role.</value>
        //public virtual Role Role { get; set; }       
    }
}