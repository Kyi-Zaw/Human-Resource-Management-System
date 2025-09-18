using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
namespace InfrastructorLayer.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<PostInfo> PostInfo { get; set; }
    public DbSet<EducationHeader> EducationHeader { get; set; }
    public DbSet<EducationHeader> EducationEducationItem { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<EducationHeader>()
            .HasKey(h => h.EducationHaderID); // Primary Key သတ်မှတ်တာပါ

        modelBuilder.Entity<EducationItem>()
            .HasKey(i => i.EducationItemID); // Primary Key သတ်မှတ်တာပါ

        modelBuilder.Entity<EducationItem>()
            .HasOne(i => i.EducationHeader) // EducationItem တိုင်းမှာ Header တစ်ခုရှိမယ် (FK)
            .WithMany(h => h.EducationItems) // EducationHeader တစ်ခုမှာ EducationItems အများကြီး ရှိနိုင်မယ်
            .HasForeignKey(i => i.EducationHeaderID) //FK column ကို HeaderId အနေနဲ့ သတ်မှတ်မယ်
            .OnDelete(DeleteBehavior.Cascade); //Header ကို Delete လုပ်သွားရင် အဲဒီ Header ရဲ့ Items တွေကိုပါ Auto Delete လုပ်မယ်
    }
}
