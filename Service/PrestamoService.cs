﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using FreimyHidalgo_Ap1_P1.Models;
using System.ComponentModel.DataAnnotations;
using FreimyHidalgo_Ap1_P1.DAL;
using FreimyHidalgo_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


/*Control alt l*/

namespace FreimyHidalgo_Ap1_P1.Service
{
	public class PrestamoService
	{


		private readonly Context _context;


		public PrestamoService(Context context)
		{
			_context = context;
		}

		public async Task<bool> Existe(int id)
		{
			return await _context.Prestamos.AnyAsync();
		}
		
		public async Task<bool> Insertar(Prestamos prestamos)
		{
			_context.Prestamos.Add(prestamos);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> Modificar(Prestamos prestamos)
		{
			_context.Prestamos.Update(prestamos);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> Guardar(Prestamos prestamos)
		{
			if(!await Existe(prestamos.PrestamoId))
				return await Insertar(prestamos);
			   return await Modificar(prestamos);

		}   

		public async Task<bool> Eliminar(int id)
		{
			var prestamo = await _context.Prestamos.FirstOrDefaultAsync(p => p.PrestamoId == id);
			if(prestamo != null)
			{
				_context.Prestamos.Remove(prestamo);
				return await _context.SaveChangesAsync() > 0;
			}
			return false;
		}

		public async Task<List<Prestamos>> Listar(Expression<Func<Prestamos, bool>> criterio)
		{
			return _context.Prestamos.AsNoTracking()
				.Where(criterio)
				.ToList(); 
		}

		public async Task<Prestamos> Buscar(int incentivo)
		{
			return _context.Prestamos.AsNoTracking()
				.FirstOrDefault(p => p.Interes == incentivo);
		}

		public async Task<Prestamos?> ValidarDeudor(string deudor)
		{
			return await _context.Prestamos.AsNoTracking()
				.FirstOrDefaultAsync(p => p.deudor == deudor);

		} 

		public async Task<bool> Validar(int id)
		{
			return await _context.Prestamos.AnyAsync(p => p.PrestamoId == id);

		}

		/*public decimal calcularInteresPrestamo(decimal )
		{
			return 
		}*/



	}
}
