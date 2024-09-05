using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaProjetos1._3.Models;
using SitemaProjetos1._3.Models;

namespace SistemaProjetos1._3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SistemaProjetos1._3.Models.Usuario> Usuario { get; set; } = default!;
        public DbSet<SitemaProjetos1._3.Models.Projeto> Projeto { get; set; } = default!;
        public DbSet<SistemaProjetos1._3.Models.Acao> Acao { get; set; } = default!;
    }
}
