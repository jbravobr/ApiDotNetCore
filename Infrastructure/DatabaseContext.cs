using ApiDotNetCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApiDotNetCore.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        public DbSet<Address> Address { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:crmapi.database.windows.net,1433;Initial Catalog=infnetCRMAPI;Persist Security Info=False;User ID=ramaral;Password=r48xmxdmc44wwW;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        } 
    }
}