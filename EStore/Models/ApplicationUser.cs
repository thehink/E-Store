using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EStore.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
