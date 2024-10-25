using FreimyHidalgo_Ap1_P1.Models;
using FreimyHidalgo_Ap1_P1.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace FreimyHidalgo_Ap1_P1.Service
{
    public class CobroService
    {
        private readonly Context _context;

        public CobroService(Context context)
        {
            _context = context;

        }


        public async Task<bool> Existe(int id)
        {
            return await _context.Cobros.AnyAsync(c => c.CobroId == id);
        }

        public async Task<bool> Insertar(Cobros cobros)
        {
            _context.Cobros.Add(cobros);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Cobros cobros)
        {
            _context.Cobros.Update(cobros);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Cobros cobros)
        {
            if (!await Existe(cobros.CobroId))
                return await Insertar(cobros);

            _context.Entry(cobros).State = EntityState.Modified;
            foreach (var detalle in cobros.CobroDetalles)
            {
                _context.Entry(detalle).State = detalle.DetalleId == 0 ?
                    EntityState.Added : EntityState.Modified;
            }
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> Eliminar(int id)
        {
            var cobro = await _context.Cobros.FirstOrDefaultAsync(c => c.CobroId == id);
            if (cobro != null)
            {
                _context.Cobros.Remove(cobro);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

       public async Task<Cobros?> Buscar(int id)
        {
            return await _context.Cobros
                .Include(c => c.CobroDetalles)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CobroId == id);
        }

      

        public async Task<List<Deudores>> ListarDeudor()
        {
            return await _context.Deudores
                .AsNoTracking()  
                .ToListAsync();
        }

        public async Task<Prestamos> ObtenerDeudor(int deudorId)
        {
          
            var prestamo = await _context.Prestamos
                .Include(p => p.deudor) 
                .FirstOrDefaultAsync(p => p.DeudorId == deudorId); 

            return prestamo;
        }

        public async Task<List<Cobros>> Listar(Expression<Func<Cobros, bool>> criterio)
        {
            return _context.Cobros.Include(d => d.Deudores) // si da error poner deudor a ver que pasa
                .Include(d => d.CobroDetalles)
                .AsNoTracking()
                .Where(criterio)
                .ToList();
        }

        /*public async Task<Cobros> Buscar(int id)
		{
			return _context.Cobros.Include(d => d.Deudores)  // si da error poner deudor a ver que pasa
				.Include(c => c.CobroDetalles)
				.AsNoTracking()
				.FirstOrDefaultAsync(d => d.DeudorId == id);
		}*/


    }

}