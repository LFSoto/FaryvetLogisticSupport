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
            annioFabricacion = 1970;
            fechaVencimientoCVOSenasa = DateTime.Now;
            fechaVencimientoSalidaPais = DateTime.Now;
        }
        [Key]
        [Required (ErrorMessage = "La placa es requerida")]
        public string placa { get; set; }

        [Required(ErrorMessage = "La capacidad de carga es requerida")]

        [Range(0, float.MaxValue, ErrorMessage = "No se admiten valores negativos")]
        public float capacidadCarga { get; set; }

        [Required(ErrorMessage = "El estado de vehiculo es requerido")]
        public string estado { get; set; }

        [Required(ErrorMessage = "El campo del CVO de Senasa es requerido")]
        public bool CVOSenasa { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaVencimientoCVOSenasa { get; set; }

        [Required(ErrorMessage = "La marca del vehiculo es requerida")]
        public string marca { get; set; }

        [Required(ErrorMessage = "El modelo del vehiculo es requerido")]
        public string modelo { get; set; }

        [Required(ErrorMessage = "El año de fabricacion del vehiculo es requerido")]
        [CustomDataAnnotationYear (ErrorMessage = "El año de fabricación es requerido")]
        public int annioFabricacion { get; set; }

        [StringLength(2)]
        [Required(ErrorMessage = "La licencia es requerida")]
        public string licenciaRequerida { get; set; }

        [Required(ErrorMessage = "El campo de permiso de salida del pais es requerido")]
        public bool salidaPais { get; set; }
        [Column(TypeName = "date")]
        public DateTime fechaVencimientoSalidaPais { get; set; }

        [Required(ErrorMessage = "Debe indicar si el vehiculo es de reparto")]
        public bool isReparto { get; set; }

        public virtual ICollection<Entrega> Entregas { get; set; }
    }
}
