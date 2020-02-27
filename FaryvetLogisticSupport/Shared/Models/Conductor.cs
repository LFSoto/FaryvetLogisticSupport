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

        public Conductor()
        {
            Entregas = new HashSet<Entrega>();
            fechaVencimientoB = DateTime.Now;
            fechaVencimientoA = DateTime.Now;
            fechaDeContratacion = DateTime.Now;
        }

        [Key]
        [Required(ErrorMessage = "El campo cedula es requerido")]
        public string cedula { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El campo apellido paterno es requerido")]
        public string apellido1 { get; set; }

        [Required(ErrorMessage = "El campo apellido materno es requerido")]
        public string apellido2 { get; set; }

        [Range(0, 4, ErrorMessage = "Licencia no valida, El valor se debe encontrar dentro del rango: 0-4")]
        public int licenciaB { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaVencimientoB { get; set; }

        [Range(0, 3, ErrorMessage = "Licencia no valida, El valor se debe encontrar dentro del rango: 0-3")]
        public int licenciaA { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaVencimientoA { get; set; }

        [Required]
        public string estado { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [CustomDataAnnotationDate]
        public DateTime fechaDeContratacion { get; set; }

        public virtual ICollection<Entrega> Entregas { get; set; }
    }
}