namespace Data
{
    using Data.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }
        
        public DbSet<Country> Countries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shift> Shifts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasRequired(c => c.Country)
                .WithMany(c => c.Employees);

            base.OnModelCreating(modelBuilder);
        }
    }
    
}