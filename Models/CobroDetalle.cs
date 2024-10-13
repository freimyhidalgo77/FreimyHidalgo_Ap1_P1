using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FreimyHidalgo_Ap1_P1.Models
{
	public class CobroDetalle
	{
		[Key]

		public int DetalleId { get; set; }

		public int CobroId { get; set; }
		[ForeignKey("CobroId")]

		public int PrestamoId { get; set; } 
        [ForeignKey("PrestamoId")]

        public Prestamos prestamos { get; set; }

		[Required (ErrorMessage ="Campo valor cobro obligatorio")]
		public double valorCobrado { get; set; }



	}
}
