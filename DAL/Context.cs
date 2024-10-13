using Microsoft.EntityFrameworkCore;
using FreimyHidalgo_Ap1_P1.Models;


namespace FreimyHidalgo_Ap1_P1.DAL
{
	public class Context : DbContext
	{

		public Context(DbContextOptions<Context> option) : base(option) 
		{ 
		}

		public DbSet<Prestamos> Prestamos { get; set; }
		public DbSet<Deudores> Deudores { get; set; }

		public DbSet<Cobros> Cobros { get; set; }
		public DbSet<CobroDetalle> CobroDetalles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Deudores>().HasData(new List<Deudores>()
			{
				new Deudores(){DeudorId = 1, nombre = "Juan Perez"},
				new Deudores(){DeudorId = 2, nombre = "Cristal Hernandez"},
                new Deudores(){DeudorId = 3, nombre = "Maria Sanchez"},
                new Deudores(){DeudorId = 4, nombre = "Hancock Smith"}

			});

		}
	}
}
                       