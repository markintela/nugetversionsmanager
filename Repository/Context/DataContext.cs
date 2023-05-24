using Microsoft.EntityFrameworkCore;
using Model;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Sprint> Sprint { get; set; }
        public DbSet<Solution> Solution { get; set; }
        public DbSet<CardJira> CardJira { get; set; }
        public DbSet<Developer> Developer { get; set; }
        public DbSet<EpicFeature> EpicFeature { get; set; }
        public DbSet<ManagerVersion> ManagerVersion { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
