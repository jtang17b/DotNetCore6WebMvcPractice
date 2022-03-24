using DotNetCore6WebMVCPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore6WebMVCPractice.Data;

public class ApplicationDbContext :DbContext{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Category> Categories {get; set;}
}