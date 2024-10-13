using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FreimyHidalgo_Ap1_P1.Models
{
	public class Deudores
	{

		[Key]

		public int DeudorId { get; set; }


		[Required(ErrorMessage = "El campo nombre es obligatorio")]
		[RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El campo solo puede contener letras y espacios.")]
		public string nombre { get; set; }

	}
}
 