using Microsoft.EntityFrameworkCore;
using Dominio.Models;
using Oracle.EntityFrameworkCore.Infrastructure;


namespace Infraestructura.Persistencia
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Poliza> Polizas { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Tab_locat> Tab_Locats { get; set; }
        public DbSet<Premium> Premiums { get; set; }
        public DbSet<Productmaster> Productmasters { get; set; }
        public DbSet<RamoComercial> RamoComercials { get; set; }
        public DbSet<MotAnulacionPoliza> MotAnulacionPolizas { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
        public DbSet<MedioDePago> MediosDePago {  get; set; }
        public DbSet<Nacionalidad> Nacionalidades {  get; set; }
        public DbSet<MotAnulacionRecibo> MotAnulacionRecibos { get; set; }
        public DbSet<Users> Users { get; set; }
        
        public DbSet<PolicyHistory> PolicyHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Poliza>().ToTable("POLIZA");
            // Define PK compuesta
            modelBuilder.Entity<Poliza>().HasKey(p => new { p.Nbranch, p.Nproduct, p.Npolicy });
            //Define FK
            modelBuilder.Entity<Poliza>()
                .HasOne(p => p.Client)
                .WithMany()
                .HasForeignKey(p => p.Sclient);
            modelBuilder.Entity<Poliza>()
                .HasOne(p => p.Way_pay)
                .WithMany()
                .HasForeignKey(p => p.Nway_pay);
            modelBuilder.Entity<Poliza>()
                .HasOne(p => p.NullCode)
                .WithMany()
                .HasForeignKey(p => p.Nnullcode);
            modelBuilder.Entity<Poliza>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.Nusercode);
            modelBuilder.Entity<Poliza>()
                .HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => new { p.Nbranch, p.Nproduct });

            modelBuilder.Entity<Client>().ToTable("CLIENTS");
            modelBuilder.Entity<Client>().HasKey(c => c.Sclient);
            // Define FK Cliente
            modelBuilder.Entity<Client>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.Nusercode);
            modelBuilder.Entity<Client>()
               .HasOne(p => p.Sex)
               .WithMany()
               .HasForeignKey(p => p.Ssexclien);
            modelBuilder.Entity<Client>()
               .HasOne(p => p.Nacionality)
               .WithMany()
               .HasForeignKey(p => p.Nnationality);


            modelBuilder.Entity<Address>().ToTable("ADDRESS");
            modelBuilder.Entity<Address>().HasKey(a => new { a.Nrecowner, a.Skeyaddress, a.Sinfor });
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Municipio)
                .WithMany() // Sin relación inversa explícita
                .HasForeignKey(a => a.Nmunicipality)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Provincia)
                .WithMany() // Sin relación inversa explícita
                .HasForeignKey(a => a.Nprovince)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Localidad)
                .WithMany() // Sin relación inversa explícita
                .HasForeignKey(a => a.Nlocal)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Branch)
                .WithMany() // Sin relación inversa explícita
                .HasForeignKey(a => a.Nbranch)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Producto)
                .WithMany() // Sin relación inversa explícita
                .HasForeignKey(a => new { a.Nbranch, a.Nproduct })
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Poliza)
                .WithMany() // Sin relación inversa explícita
                .HasForeignKey(a => new { a.Nbranch, a.Nproduct, a.Npolicy })
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Cliente)
                .WithMany() // Sin relación inversa explícita
                .HasForeignKey(a => a.Sclient)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Usuario)
                .WithMany() // Sin relación inversa explícita
                .HasForeignKey(a => a.Nusercode)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Municipality>().ToTable("MUNICIPALITY");
            modelBuilder.Entity<Municipality>().HasKey(m => m.Nmunicipality);
            modelBuilder.Entity<Municipality>()
                .HasOne(m => m.Provincia)
                .WithMany() // Sin relación inversa explícita
                .HasForeignKey(m => m.Nprovince)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Province>().ToTable("PROVINCE");
            modelBuilder.Entity<Province>().HasKey(p => p.Nprovince);
            modelBuilder.Entity<Province>()
               .HasOne(p => p.Usuario)
               .WithMany() // Sin relación inversa explícita a menos que esté definida
               .HasForeignKey(p => p.Nusercode)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tab_locat>().ToTable("TAB_LOCAT");
            modelBuilder.Entity<Tab_locat>().HasKey(t => t.Nlocal);

            modelBuilder.Entity<Premium>().ToTable("PREMIUM");
            modelBuilder.Entity<Premium>().HasKey(p => new { p.Nbranch, p.Nproduct, p.Npolicy, p.Nreceipt });

            modelBuilder.Entity<Productmaster>().ToTable("PRODUCTMASTER");
            modelBuilder.Entity<Productmaster>().HasKey(p => new { p.Nbranch, p.Nproduct });
            // Relaciones para ProductMaster
            modelBuilder.Entity<Productmaster>()
                .HasOne(p => p.Branch)
                .WithMany()
                .HasForeignKey(p => p.Nbranch);
            modelBuilder.Entity<Productmaster>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.Nusercode);

            modelBuilder.Entity<RamoComercial>().ToTable("TABLE10");
            modelBuilder.Entity<RamoComercial>().HasKey(r => r.Nbranch);

            modelBuilder.Entity<MotAnulacionPoliza>().ToTable("TABLE13");
            modelBuilder.Entity<MotAnulacionPoliza>().HasKey(m => m.Nnullcode);

            modelBuilder.Entity<Sexo>().ToTable("TABLE18");
            modelBuilder.Entity<Sexo>().HasKey(s => s.Ssexclien);

            modelBuilder.Entity<MedioDePago>().ToTable("TABLE5002");
            modelBuilder.Entity<MedioDePago>().HasKey(s => s.Nway_pay);
            modelBuilder.Entity<MedioDePago>()
                .HasOne(m => m.Usuario)
                .WithMany()
                .HasForeignKey(m => m.Nusercode);

            modelBuilder.Entity<Nacionalidad>().ToTable("TABLE5518");
            modelBuilder.Entity<Nacionalidad>().HasKey(n => n.Nnationality);

            modelBuilder.Entity<MotAnulacionRecibo>().ToTable("TABLE95");
            modelBuilder.Entity<MotAnulacionRecibo>().HasKey(n => n.Nnullcode);

            modelBuilder.Entity<Users>().ToTable("USUARIOS");
            modelBuilder.Entity<Users>().HasKey(n => n.Nusercode);

            modelBuilder.Entity<PolicyHistory>().ToTable("POLIZA_HISTORY");
            modelBuilder.Entity<PolicyHistory>().HasKey(p => new { p.Nbranch, p.Nproduct, p.Npolicy, p.Nmovment} );
            modelBuilder.Entity<PolicyHistory>()
               .HasOne(p => p.Client)
               .WithMany()
               .HasForeignKey(p => p.Sclient);
            modelBuilder.Entity<PolicyHistory>()
                .HasOne(p => p.Way_pay)
                .WithMany()
                .HasForeignKey(p => p.Nway_pay);
            modelBuilder.Entity<PolicyHistory>()
                .HasOne(p => p.NullCode)
                .WithMany()
                .HasForeignKey(p => p.Nnullcode);
            modelBuilder.Entity<PolicyHistory>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.Nusercode);
            modelBuilder.Entity<PolicyHistory>()
                .HasOne(p => p.Branch)
                .WithMany()
                .HasForeignKey(p => p.Nbranch);
            modelBuilder.Entity<PolicyHistory>()
                .HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => new { p.Nbranch, p.Nproduct });

            base.OnModelCreating(modelBuilder);
        }
    }
}