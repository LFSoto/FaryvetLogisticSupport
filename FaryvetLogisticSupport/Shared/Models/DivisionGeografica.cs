using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FaryvetLogisticSupport.Shared.Models
{

    /* 
    * @class DivisionGeografica.
    * @brief Modelo para el manejo de DivisionGeografica en la aplicación.
    */
   
    [Table("FLS_DisionesGeograficas")]
    public class DivisionGeografica
    {
        /* 
         * @brief Get y Set del atributo codigoPostal
         */
        [Key]
        [Required]
        public int codigoPostal { get; set; }
        /* 
       * @brief Get y Set del atributo ubicacion
       */
        [Required]
        public string ubicacion { get; set; }
    }
}
