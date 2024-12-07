using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class InstagramContext : DbContext
    {
        public DbSet<Instagram> Instagrams { get; set; }

    }
}