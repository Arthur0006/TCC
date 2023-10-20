using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Areas.Identity.Data;
using ProjetoMVC.Models;

namespace ProjetoMVC.Data;

public class ProjetoMVCContext : IdentityDbContext<UsuarioModel>
{
    public ProjetoMVCContext(DbContextOptions<ProjetoMVCContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<ProjetoMVC.Models.MecanicaModel>? Mecanicas { get; set; }

    public DbSet<ProjetoMVC.Models.MecanicaFotosModel>? MecanicaFotos { get; set; }

    public DbSet<ProjetoMVC.Models.MarcaModel>? Marcas { get; set; }

    public DbSet<ProjetoMVC.Models.ModeloModel>? Modelos { get; set; }
}
