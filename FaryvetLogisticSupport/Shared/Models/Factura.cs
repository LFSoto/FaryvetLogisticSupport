using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FaryvetLogisticSupport.Shared.Models
{
    [Table("FLS_Facturas")]
    public class Factura
    {
        public Factura()
        {
            entrega = 0;
            comentarios = "";
            EntregaNavigation = new Entrega();
            DivisionGeograficaNavigation = new DivisionGeografica();
        }
        [Key]
        [Required]
        public string id { get; set; }
        public int? entrega { get; set; }
        [Required]
        public string formaDespacho { get; set; }
        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "No se admiten valores negativos")]
        public float pesoTotal { get; set; }
        [Required]
        public string formaCobro { get; set; }
        [Required]
        public string moneda { get; set; }
        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "No se admiten valores negativos")]
        public float montoTotal { get; set; }
        [Required]
        public string nombreCliente { get; set; }
        public string comentarios { get; set; }
        [Required]
        public string estado { get; set; }
        [Required]
        public int ubicacion { get; set; }
        [Required]
        public string direccion { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }
        [ForeignKey("entrega")]
        public virtual Entrega EntregaNavigation { get; set; }
        [ForeignKey("ubicacion")]
        public virtual DivisionGeografica DivisionGeograficaNavigation { get; set; }
    }
}
