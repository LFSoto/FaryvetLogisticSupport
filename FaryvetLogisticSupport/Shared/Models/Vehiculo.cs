using FaryvetLogisticSupport.Shared.CustomDataAnnotation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FaryvetLogisticSupport.Shared.Models
{
    [Table("FLS_Vehiculos")]
    public class Vehiculo
    {
        public Vehiculo()
        {
            Entregas = new HashSet<Entrega>();
        }
        [Key]
        [Required]
        public string placa { get; set; }
        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "No se admiten valores negativos")]
        public float capacidadCarga { get; set; }
        [Required]
        public string estado { get; set; }
        [Required]
        public bool CVOSenasa { get; set; }
        [Column(TypeName = "date")]
        public DateTime fechaVencimientoCVOSenasa { get; set; }
        [Required]
        public string marca { get; set; }
        [Required]
        public string modelo { get; set; }
        [Required]
        [CustomDataAnnotationYear]
        public int annioFabricacion { get; set; }
        [StringLength(2)]
        [Required]
        public string licenciaRequerida { get; set; }
        [Required]
        public bool salidaPais { get; set; }
        [Column(TypeName = "date")]
        public DateTime fechaVencimientoSalidaPais { get; set; }
        [Required]
        public bool isReparto { get; set; }

        public virtual ICollection<Entrega> Entregas { get; set; }
    }
}
