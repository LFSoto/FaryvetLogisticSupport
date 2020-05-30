using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FaryvetLogisticSupport.Shared.Models
{

    /// <summary>
    /// Clase DivisionGeografica.
    /// Modelo para el manejo de DivisionGeografica en la aplicación.
    /// </summary>
    [Table("FLS_DisionesGeograficas")]
    public class DivisionGeografica
    {
        /// <value>Get y Set del atributo codigoPostal</value>
        [Key]
        [Required]
        public int codigoPostal { get; set; }
        /// <value>Get y Set del atributo ubicacion</value>
        [Required]
        public string ubicacion { get; set; }
    }
}
