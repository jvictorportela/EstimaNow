using Microsoft.EntityFrameworkCore;

namespace EstimaNow.Infrastructure.DataAccess;

public class EstimaNowDbContext : DbContext
{
    public EstimaNowDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }


}