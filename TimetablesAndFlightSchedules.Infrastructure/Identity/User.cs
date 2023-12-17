using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablesAndFlightSchedules.Infrastructure.Identity
{
    /// <summary>
    /// Our User class which can be modified
    /// </summary>
    public class User : IdentityUser<int>
    {
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
    }
}