using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Group41_Wired_Martians.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Users class
public class Users : IdentityUser
{
    public string? ImgUrl { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Status { get; set; }
    public DateTime? CreatedAt { get; set; }

}

