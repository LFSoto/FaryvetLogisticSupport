using FaryvetLogisticSupport.Shared.CustomDataAnnotation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FaryvetLogisticSupport.Shared.Models
{
    [Table("FLS_Conductores")]
    public class Conductor
    {
        [Key]
        [Required]
        public string cedula { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido1 { get; set; }
        [Required]
        public string apellido2 { get; set; }
        [Range(0, 4, ErrorMessage = "Licencia no valida")]
        public int licenciaB { get; set; }
        [Column(TypeName = "date")]
        public DateTime fechaVencimientoB { get; set; }
        [Range(0, 3, ErrorMessage = "Licencia no valida")]
        public int licenciaA { get; set; }
        [Column(TypeName = "date")]
        public DateTime fechaVencimientoA { get; set; }
        [Required]
        public string estado { get; set; }
        [Required]
        [Column(TypeName = "date")]
        [CustomDataAnnotationDate]
        public DateTime fechaContrado { get; set; }

        public virtual ICollection<Entrega> Entregas { get; set; }
    }
}
