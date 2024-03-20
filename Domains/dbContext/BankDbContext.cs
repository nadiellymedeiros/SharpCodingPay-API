using Microsoft.EntityFrameworkCore;
using SharpCodingAPI.Domains.Models;

namespace SharpCodingAPI.Domains.DTO.dbContext;


public class BankDbContext : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<Transacoes> Transacoes { get; set; }
    



public BankDbContext(DbContextOptions<BankDbContext> options) 
    : base(options){
    }

}