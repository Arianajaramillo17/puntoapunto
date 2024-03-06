using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enty=Service.Cotizacion.Core.Entities;
using   Common.Core.Base;

using DateHelp=Common.Application.Helpers.DateTimeHelper;
using Service.Cotizacion.Infrastructure.Configurations;

using Microsoft.EntityFrameworkCore;
namespace Service.Cotizacion.Infrastructure
{
    public class CotizacionDbContext : DbContext
    {
      private readonly DateHelp _helper = new DateHelp();
        public CotizacionDbContext(DbContextOptions<CotizacionDbContext> options) : base(options)
        {
        }
        public DbSet<Enty.Cotizacion> Cotizaciones { get; set; }
        public DbSet<Enty.CotizacionDetalle> CotizacionesDetalles { get; set; }
        public DbSet<Enty.EstadoCotizacion> EstadosCotizaciones{ get; set; }
        public DbSet<Enty.MaterialPrimario> MaterialesPrimarios { get; set; }
        public DbSet<Enty.TipoMaterial> TiposMateriales { get; set; }
      


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("crm");
            ModelConfig(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new CotizacionConfiguration(modelBuilder.Entity<Enty.Cotizacion>());
            new CotizacionDetalleConfiguration(modelBuilder.Entity<Enty.CotizacionDetalle>());
            new EstadoCotizacionConfiguration(modelBuilder.Entity<Enty.EstadoCotizacion>());
            new MaterialPrimarioConfiguration(modelBuilder.Entity<Enty.MaterialPrimario>());
            new TipoMaterialConfiguration(modelBuilder.Entity<Enty.TipoMaterial>());


            modelBuilder.Entity<Enty.Cotizacion>().ToTable("Cotizaciones");
            modelBuilder.Entity<Enty.CotizacionDetalle>().ToTable("CotizacionesDetalles");
            modelBuilder.Entity<Enty.EstadoCotizacion>().ToTable("EstadosCotizaciones");
            modelBuilder.Entity<Enty.MaterialPrimario>().ToTable("MaterialesPrimarios");
            modelBuilder.Entity<Enty.TipoMaterial>().ToTable("TiposMateriales");
        
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _helper.DateTimePst();//DateTime.Now.AddHours(-5);
                        break;
                    case EntityState.Modified:
                        entry.Entity.Modified = _helper.DateTimePst();//DateTime.Now.AddHours(-5);
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DateTime DateTimePst()
        {
            try
            {
                DateTime fServer = DateTime.UtcNow;
                TimeZoneInfo timeLima = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
                return fServer = TimeZoneInfo.ConvertTimeFromUtc(fServer, timeLima);
            }
            catch
            {
                return DateTime.Now;
            }
        }
    }
}