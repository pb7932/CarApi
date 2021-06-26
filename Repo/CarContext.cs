using CarApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CarApi.Repo
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> opt) : base(opt)
        {

        }

        public DbSet<Car> Cars { get; set; }
    }
}