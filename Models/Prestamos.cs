using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FreimyHidalgo_Ap1_P1.Models

{
	public class Prestamos 
	{

		[Key]

		public int PrestamoId { get; set; }

		[Required(ErrorMessage="Campo concepto obligatorio")]

		public string Concepto { get; set; }


		[Required(ErrorMessage = "Campo deudor obligatorio")]

		
		public string deudor { get; set; }


		[Required(ErrorMessage = "Campo monto obligatorio")]

		public decimal  monto { get; set; }

		[Required(ErrorMessage = "Campo monto obligatorio")]
		public decimal Interes { get; set; }

		   
		  

	}
}
