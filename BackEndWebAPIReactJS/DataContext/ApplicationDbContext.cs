using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndWebAPIReactJS.Models;

namespace BackEndWebAPIReactJS.DataContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //public DbSet<deepak_siteMaster> deepak_SiteMasters;
        //public DbSet<deepak_siteAddress> deepak_SiteAddresses;
        //public DbSet<deepak_lkpStatus> deepak_LkpStatuses;
        //public DbSet<deepak_lkpSiteType> deepak_LkpSiteTypes;
        //public DbSet<deepak_lkpManager> deepak_LkpManagers;
        //public DbSet<deepak_lkpAssignedTo> deepak_LkpAssignedTos;
        //public DbSet<deepak_lkpAddress> deepak_LkpAddresses;


    }
}
