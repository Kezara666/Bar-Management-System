using Bar_Management_System.Model.InvoiceManagement;
using Bar_Management_System.Model.ProductManagement;
using Bar_Management_System.Model.SupplierManagement;
using Data.Model.BranchManagement;
using Data.Model.UserManagement;
using Microsoft.EntityFrameworkCore;

public class BMSContext : DbContext
{
    public BMSContext(DbContextOptions<BMSContext> options) : base(options) { }
    public BMSContext()
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Window> Windows { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Invoice> Invoice { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=172.212.81.114;Database=BMS;User Id=sa;Password=admin@123;TrustServerCertificate=True");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

    }

    }
