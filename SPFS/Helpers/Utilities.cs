
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;
using SPFS.Models;
using SPFS.DAL;

namespace SPFS.Helpers
{
    /// <summary>
    /// Class Utilities.
    /// </summary>
    public class Utilities
    {
        /// <summary>
        /// The admi n_ role
        /// </summary>
        public const string ADMIN_ROLE = "Admin";
        /// <summary>      
        public const string AUTHOR_ROLE = "Author";
      
        public const string SERVICEDESK_ROLE = "ServiceDesk";

        public const string APPROVED_ROLES = "Admin,Author,ServiceDesk";
        /// <summary>
        /// The edi _ user  roles
        /// </summary>
        public const string ADMIN_OFFICE_USERS_ROLES = "Admin, ServiceDesk";
       
        /// <summary>
        /// The canno t_ fin d_ user
        /// </summary>
        public const string CANNOT_FIND_USER = "Cannot find user. Please contact administrator.";

        /// <summary>
        /// The _current user name
        /// </summary>
        //private string _currentUserName = "";
        /// <summary>
        /// Gets or sets the name of the current user.
        /// </summary>
        /// <value>The name of the current user.</value>
        public string CurrentUserName
        {
            get
            {
                if (HttpContext.Current.User == null || HttpContext.Current.User.Identity == null || String.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
                    throw new Exception("Current User is null");

                return StripDomainName(HttpContext.Current.User.Identity.Name);
            }       
        }

        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <returns>User.</returns>
        /// <exception cref="Exception"></exception>
        public SPFS_USERS GetCurrentUser()
        {
            //return new User() { ADUserID = "xyz", UserName = "Test" };
            SPFS.DAL.SPFSEntities db = new SPFSEntities();
            
            IQueryable<SPFS_USERS> users = db.SPFS_USERS.Where(p => p.UserName== CurrentUserName);
            if (users != null && users.Count() > 0)
            {
                return users.FirstOrDefault();
            }
            else
                throw new Exception(CANNOT_FIND_USER);
        }

        /// <summary>
        /// Gets the roles CSV.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns>System.String.</returns>
        public string GetRolesCSV(string[] roles)
        {
            return String.Join(",", roles);
        }

        /// <summary>
        /// Determines whether [is current user in role] [the specified role].
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns><c>true</c> if [is current user in role] [the specified role]; otherwise, <c>false</c>.</returns>
        public bool IsCurrentUserInRole(string role)
        {
            string[] roles = GetRolesForCurrentUser();

            if (roles != null)
                return roles.Contains(role);
            else
                return false;
        }

        /// <summary>
        /// Gets the roles for current user.
        /// </summary>
        /// <returns>System.String[].</returns>
        public string[] GetRolesForCurrentUser(string user = "")
        {
            try
            {
                string userName = string.Empty;

                if (!string.IsNullOrEmpty(user))
                {                    
                    userName = StripDomainName(user);
                }
                else
                {
                    userName = CurrentUserName;
                }

                //DVS_PCardContext db = new DVS_PCardContext();                    
                return new string[] { "Admin" };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Strips the name of the domain.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="Exception">Invalid username.</exception>
        private string StripDomainName(string userName)
        {
            if (!String.IsNullOrEmpty(userName))
                if (userName.Contains('\\'))
                    return userName.Split('\\')[1];
                else
                    return userName;
            else
            {
                throw new Exception("Invalid username. - " + userName + " -");
            }
        }

        /// <summary>
        /// Determines whether this instance is admin.
        /// </summary>
        /// <returns><c>true</c> if this instance is admin; otherwise, <c>false</c>.</returns>
        public  bool IsAdmin()
        {   
            return IsCurrentUserInRole(Utilities.ADMIN_ROLE);
        }

        /// <summary>
        /// Gets the person location identifier.
        /// </summary>
        /// <returns>System.Int32.</returns>
        //public int GetPersonLocationID()
        //{
        //    DVS_PCardContext db = new DVS_PCardContext();
        //    int locationID = db.Users.Where(p => p.ADUserID == CurrentUserName).First().LocationID.HasValue ? db.Users.Where(p => p.ADUserID == CurrentUserName).First().LocationID.Value : 0;
        //    return locationID;
        //}

        /// <summary>
        /// Gets the application minimum date.
        /// </summary>
        /// <returns>DateTime.</returns>
        public static DateTime GetApplicationMinDate()
        {
            return Convert.ToDateTime(ConfigurationManager.AppSettings["ApplicationMinDate"]);
        }

        /// <summary>
        /// Creates the entity with values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">The values.</param>
        /// <returns>T.</returns>
        public static T CreateEntityWithValues<T>(DbPropertyValues values) where T : new()
        {
            T entity = new T();
            Type type = typeof(T);

            foreach (var name in values.PropertyNames)
            {
                var property = type.GetProperty(name);
                property.SetValue(entity, values.GetValue<object>(name));
            }
            return entity;
        }

        /// <summary>
        /// Gets the inner most exception.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns>Exception.</returns>
        public static Exception GetInnerMostException(Exception ex)
        {
            Exception innerException = ex;
            while (innerException.InnerException != null)
            {
                innerException = innerException.InnerException;
            }

            return innerException;
        }
    }
}