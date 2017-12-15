namespace Data
{
    using Data.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Context : DbContext
    {
        public Context()
            : base("name=Employees")
        {
        }
        
        public DbSet<Country> Countries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<ShiftControl> ShiftControl { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasRequired(c => c.Country)
                .WithMany(c => c.Employees);

            modelBuilder.Entity<Employee>()
                .HasRequired(c => c.CurrentShift)
                .WithMany(c => c.Employees);

            base.OnModelCreating(modelBuilder);
        }
    }
    
}