using FaryvetLogisticSupport.Shared.CustomDataAnnotation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FaryvetLogisticSupport.Shared.Models
{
    /// <summary>
    /// Clase Vehiculo.
    /// Modelo para el manejo de Vehiculo en la aplicación.
    /// </summary>
    [Table("FLS_Vehiculos")]
    public class Vehiculo
    {
        /// <summary>
        /// Constructor de la clase Vehiculo
        /// Inicializa la fechaVencimientoCVOSenasa y fechaVencimientoSalidaPais con la fecha actual.
        /// </summary>
        public Vehiculo()
        {
            annioFabricacion = 1970;
            fechaVencimientoCVOSenasa = DateTime.Now;
            fechaVencimientoSalidaPais = DateTime.Now;
        }

        /// <value>Get y Set del atributo placa</value>
        [Key]
        [Required (ErrorMessage = "La placa es requerida")]
        public string placa { get; set; }

        /// <value>Get y Set del atributo capacidadCarga</value>
        [Required(ErrorMessage = "La capacidad de carga es requerida")]
        [Range(0, float.MaxValue, ErrorMessage = "No se admiten valores negativos")]
        public float capacidadCarga { get; set; }

        /// <value>Get y Set del atributo estado</value>
        [Required(ErrorMessage = "El estado de vehiculo es requerido")]
        public string estado { get; set; }

        /// <value>Get y Set del atributo CVOSenasa</value>
        [Required(ErrorMessage = "El campo del CVO de Senasa es requerido")]
        public bool CVOSenasa { get; set; }

        /// <value>Get y Set del atributo fechaVencimientoCVOSenasa</value>
        [Column(TypeName = "date")]
        public DateTime fechaVencimientoCVOSenasa { get; set; }

        /// <value>Get y Set del atributo marca</value>
        [Required(ErrorMessage = "La marca del vehiculo es requerida")]
        public string marca { get; set; }

        /// <value>Get y Set del atributo modelo</value>
        [Required(ErrorMessage = "El modelo del vehiculo es requerido")]
        public string modelo { get; set; }

        /// <value>Get y Set del atributo annioFabricion</value>
        [Required(ErrorMessage = "El año de fabricacion del vehiculo es requerido")]
        [CustomDataAnnotationYear (ErrorMessage = "El año de fabricación es requerido")]
        public int annioFabricacion { get; set; }

        /// <value>Get y Set del atributo licenciaRequerida</value>
        [StringLength(2)]
        [Required(ErrorMessage = "La licencia es requerida")]
        public string licenciaRequerida { get; set; }

        /// <value>Get y Set del atributo salidaPais</value>
        [Required(ErrorMessage = "El campo de permiso de salida del pais es requerido")]
        public bool salidaPais { get; set; }

        /// <value>Get y Set del atributo fechaVencimientoSalidaPais</value>
        [Column(TypeName = "date")]
        public DateTime fechaVencimientoSalidaPais { get; set; }

        /// <value>Get y Set del atributo isReparto</value>
        [Required(ErrorMessage = "Debe indicar si el vehiculo es de reparto")]
        public bool isReparto { get; set; }
    }
}
