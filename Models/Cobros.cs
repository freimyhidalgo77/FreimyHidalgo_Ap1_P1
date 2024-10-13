using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FreimyHidalgo_Ap1_P1.Models
{
	public class Cobros
	{
		[Key]

		public int CobroId {  get; set; }

		[Required(ErrorMessage ="Campo fecha obligatorio")]
		public DateTime fecha { get; set; }

        public int DeudorId { get; set; }

        [ForeignKey("DeudorId")]
		public Deudores Deudores { get; set; }

		public decimal Monto { get; set; }

		public ICollection<CobroDetalle> CobroDetalles { get; set; } = new List<CobroDetalle>();






	}
}
