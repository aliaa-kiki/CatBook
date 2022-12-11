using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;

namespace CatBook.Areas.Identity.Data;

// Add profile data for application users by adding properties to the CatBookUser class

public class CatBookUser : IdentityUser
{
    [Display(Name = "User name")]
    public string? catBookUserName { get; set; }
}

