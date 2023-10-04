using BlazorServerAppSample.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerAppSample.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ProductModel> tblProduct { get; set; }
        public DbSet<EmployeeModel> tblEmployee { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}