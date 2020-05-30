using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FaryvetLogisticSupport.Shared.Models
{
    /// <summary>
    /// Clase Factura.
    /// Modelo para el manejo de Factura en la aplicación.
    /// </summary>
    [Table("FLS_Facturas")]
    public class Factura
    {
        /// <summary>
        /// Constructor de la clase Entrega
        /// Inicializa los comentarios en "".
        /// </summary>
        public Factura()
        {
            comentarios = "";
            //EntregaNavigation = new Entrega();
            //DivisionGeograficaNavigation = new DivisionGeografica();
        }

        /// <value>Get y Set del atributo id</value>
        [Key]
        [Required]
        public string id { get; set; }

        /// <value>Get y Set del atributo entrega</value>
        public int? entrega { get; set; }

        /// <value>Get y Set del atributo formaDespacho</value>
        [Required]
        public string formaDespacho { get; set; }

        /// <value>Get y Set del atributo pesoTotal</value>
        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "No se admiten valores negativos")]
        public float pesoTotal { get; set; }

        /// <value>Get y Set del atributo formaCobro</value>
        [Required]
        public string formaCobro { get; set; }

        /// <value>Get y Set del atributo moneda</value>
        [Required]
        public string moneda { get; set; }

        /// <value>Get y Set del atributo montoTotal</value>
        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "No se admiten valores negativos")]
        public float montoTotal { get; set; }

        /// <value>Get y Set del atributo nombreCliente</value>
        [Required]
        public string nombreCliente { get; set; }

        /// <value>Get y Set del atributo comentarios</value>
        public string comentarios { get; set; }

        /// <value>Get y Set del atributo estado</value>
        [Required]
        public string estado { get; set; }

        /// <value>Get y Set del atributo ubicacion</value>
        [Required]
        public int ubicacion { get; set; }

        /// <value>Get y Set del atributo direccion</value>
        [Required]
        public string direccion { get; set; }

        /// <value>Get y Set del atributo fecha</value>
        [Required]
        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }

        /// <value>Get y Set del atributo EntregaNavigation</value>
        [ForeignKey("entrega")]
        public virtual Entrega EntregaNavigation { get; set; }

        /// <value>Get y Set del atributo DivisionGeograficaNavigation</value>
        [ForeignKey("ubicacion")]
        public virtual DivisionGeografica DivisionGeograficaNavigation { get; set; }
    }
}
