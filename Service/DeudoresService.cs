using FreimyHidalgo_Ap1_P1.DAL;
using FreimyHidalgo_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FreimyHidalgo_Ap1_P1.Service
{
	public class DeudoresService
	{


		private readonly Context _context;


		public DeudoresService(Context context)
		{
			_context = context;
		}

		public async Task<List<Deudores>> ObtenerEntidadAsync()
		{
			return await _context.Deudores.ToListAsync();
		}



	}
}
