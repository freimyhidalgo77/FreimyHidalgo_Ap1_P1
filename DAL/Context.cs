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
	}
}
                       