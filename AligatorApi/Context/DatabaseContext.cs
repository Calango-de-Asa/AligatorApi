using AligatorApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AligatorApi.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder ob)
            => ob.UseNpgsql("Host=127.0.0.1;Port=5432;Pooling=true;Database=aligatordb;Username=postgres;Password=password");
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<PersonBill>().HasKey(pb => new { pb.PersonId, pb.BillId });

           /* mb.Entity<PersonBill>()
                .HasOne<Person>(p => p.Person)
                .WithMany(pb => pb.PersonBills)
                .HasForeignKey(pb => pb.PersonId);

            mb.Entity<PersonBill>()
                .HasOne<Bill>(b => b.Bill)
                .WithMany(pb => pb.PersonBills)
                .HasForeignKey(pb => pb.BillId);*/

            mb.Entity<PersonTask>().HasKey(pt => new { pt.PersonId, pt.TaskId });
            /*
            mb.Entity<PersonTask>()
                .HasOne<Person>(p => p.Person)
                .WithMany(pt => pt.PersonTasks)
                .HasForeignKey(pt => pt.PersonId);

            mb.Entity<PersonTask>()
                .HasOne<Task>(t => t.Task)
                .WithMany(pt => pt.PersonTasks)
                .HasForeignKey(pt => pt.TaskId);*/

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public DbSet<PersonBill> PersonBills { get; set; }
        public DbSet<PersonTask> PersonTasks { get; set; }
        public DbSet<House> House { get; set; }

    }
}
