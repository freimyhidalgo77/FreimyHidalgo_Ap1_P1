using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace FreimyHidalgo_Ap1_P1.Models

{
	public class Prestamos  
	{

		[Key]
       public int PrestamoId { get; set; }

		[Required(ErrorMessage = "Campo concepto obligatorio")]

        public int DeudorId { get; set; }
        [ForeignKey("DeudorId")]
        public Deudores deudor { get; set; }

        [Required(ErrorMessage = "Campo monto obligatorio")]
        public string Concepto { get; set; }

		[Required(ErrorMessage = "Campo monto obligatorio")]
        public decimal  monto { get; set; } 

		[Required(ErrorMessage = "Campo balance obligatorio")]
		public decimal balance {  get; set; }

        public ICollection<Deudores> Deudores { get; set; } = new List<Deudores>();



        //public decimal Interes { get; set; }


    }
}
