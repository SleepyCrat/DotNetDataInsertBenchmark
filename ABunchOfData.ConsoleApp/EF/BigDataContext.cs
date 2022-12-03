using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABunchOfData.ConsoleApp.EF
{
    public class BigDataContext : DbContext
    {
        public DbSet<EFOneByOneMethodTable> EFOneByOneMethodTable { get; set; }
        public DbSet<EFLayBatchMethodTable> EFOLayBatchMethodTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DataSetupClass.DBConnString, (builder) => { builder.MaxBatchSize(DataSetupClass.batchSize); });

        }
    }
}
