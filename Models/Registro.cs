using System.ComponentModel.DataAnnotations;

namespace FreimyHidalgo_Ap1_P1.Models
{
	public class Registro
	{
		[Key]

		public string name { get; set; }

		public int id { get; set; }
	}
}
   