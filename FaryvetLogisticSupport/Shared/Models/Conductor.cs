using FaryvetLogisticSupport.Shared.CustomDataAnnotation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FaryvetLogisticSupport.Shared.Models
{
    /// <summary>
    /// Clase Conductor.
    /// Modelo para el manejo de conductores en la aplicación.
    /// </summary>
    [Table("FLS_Conductores")]
    public class Conductor
    {
        /// <summary>
        /// Constructor de la clase Conductor
        /// Inicializa la fechaVencimientoB, fechaVencimientoA y fechaDeContratacion con la fecha actual.
        /// </summary>
        public Conductor()
        {
            fechaVencimientoB = DateTime.Now;
            fechaVencimientoA = DateTime.Now;
            fechaDeContratacion = DateTime.Now;
        }

        /// <value>Get y Set del atributo cedula</value>
        [Key]
        [Required(ErrorMessage = "El campo cedula es requerido")]
        public string cedula { get; set; }

        /// <value>Get y Set del atributo nombre</value>
        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string nombre { get; set; }

        /// <value>Get y Set del atributo apellido1</value>
        [Required(ErrorMessage = "El campo apellido paterno es requerido")]
        public string apellido1 { get; set; }

        /// <value>Get y Set del atributo apellido2</value>
        [Required(ErrorMessage = "El campo apellido materno es requerido")]
        public string apellido2 { get; set; }

        /// <value>Get y Set del atributo licenciaB</value>
        [Range(0, 4, ErrorMessage = "Licencia no valida, El valor se debe encontrar dentro del rango: 0-4")]
        public int licenciaB { get; set; }

        /// <value>Get y Set del atributo fechaVencimientoB</value>
        [Column(TypeName = "date")]
        public DateTime fechaVencimientoB { get; set; }

        /// <value>Get y Set del atributo licenciaA</value>
        [Range(0, 3, ErrorMessage = "Licencia no valida, El valor se debe encontrar dentro del rango: 0-3")]
        public int licenciaA { get; set; }

        /// <value>Get y Set del atributo fechaVencimientoA</value>
        [Column(TypeName = "date")]
        public DateTime fechaVencimientoA { get; set; }

        /// <value>Get y Set del atributo estado</value>
        [Required]
        public string estado { get; set; }

        /// <value>Get y Set del atributo fechaDeContratacion</value>
        [Required]
        [Column(TypeName = "date")]
        [CustomDataAnnotationDate]
        public DateTime fechaDeContratacion { get; set; }
    }
}