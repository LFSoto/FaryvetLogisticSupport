using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FaryvetLogisticSupport.Shared.Models
{
    [Table("FLS_Entregas")]
    public class Entrega
    {
        public Entrega()
        {
            Facturas = new HashSet<Factura>();
            fechaSalida = DateTime.Now.AddHours(-6);
        }
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string chofer { get; set; }
        [Required]
        public string vehiculo { get; set; }
        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "No se admiten valores negativos")]
        public float peso { get; set; }
        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "No se admiten valores negativos")]
        public float costo { get; set; }
        public string comentarios { get; set; }
        [Required]
        public string estado { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "No se admiten valores negativos")]
        public float kilometrajeSalida { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "No se admiten valores negativos")]
        public float kilometrajeLlegada { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime fechaSalida { get; set; }
        [Column(TypeName = "date")]
        public DateTime fechaLlegada { get; set; }
        [Range(1, float.MaxValue, ErrorMessage = "No se admiten valores menores a 1")]
        public float costoOperativo { get; set; }
        public bool recargaCombustible { get; set; }
        public string comentariosLlegada { get; set; }

        [ForeignKey("chofer")]
        public virtual Conductor ConductorNavigation { get; set; }
        [ForeignKey("vehiculo")]
        public virtual Vehiculo VehiculoNavigation { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
