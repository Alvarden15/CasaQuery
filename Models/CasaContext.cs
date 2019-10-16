using Microsoft.EntityFrameworkCore;

namespace CasaQuery.Models{
    public class CasaContext:DbContext{
        public CasaContext(DbContextOptions<CasaContext> options): base(options){

        }

        public DbSet<Casa> casa {get;set;}
    }
    
}