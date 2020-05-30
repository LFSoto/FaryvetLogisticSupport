using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FaryvetLogisticSupport.Shared.Models
{
    /// <summary>
    /// Clase Entrega.
    /// Modelo para el manejo de Entrega en la aplicación.
    /// </summary>
    [Table("FLS_Entregas")]
    public class Entrega
    {
        /// <summary>
        /// Constructor de la clase Entrega
        /// Inicializa la fechaSalida con la fecha actual de Costa Rica.
        /// </summary>
        public Entrega()
        {
            fechaSalida = DateTime.Now.AddHours(-6);
        }

        /// <value>Get y Set del atributo id</value>
        [Key]
        [Required]
        public int id { get; set; }

        /// <value>Get y Set del atributo chofer</value>
        [Required]
        public string chofer { get; set; }

        /// <value>Get y Set del atributo vehiculo</value>
        [Required]
        public string vehiculo { get; set; }

        /// <value>Get y Set del atributo peso</value>
        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "No se admiten valores negativos")]
        public float peso { get; set; }

        /// <value>Get y Set del atributo costo</value>
        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "No se admiten valores negativos")]
        public float costo { get; set; }

        /// <value>Get y Set del atributo comentarios</value>
        public string comentarios { get; set; }
        
        /// <value>Get y Set del atributo estado</value>
        [Required]
        public string estado { get; set; }

        /// <value>Get y Set del atributo kilometrajeSalida</value>
        [Range(0, float.MaxValue, ErrorMessage = "No se admiten valores negativos")]
        public float kilometrajeSalida { get; set; }

        /// <value>Get y Set del atributo kilometrajeLlegada</value>
        [Range(0, float.MaxValue, ErrorMessage = "No se admiten valores negativos")]
        public float kilometrajeLlegada { get; set; }

        /// <value>Get y Set del atributo fechaSalida</value>
        [Required]
        [Column(TypeName = "date")]
        public DateTime fechaSalida { get; set; }

        /// <value>Get y Set del atributo fechaLlegada</value>
        [Column(TypeName = "date")]
        public DateTime fechaLlegada { get; set; }

        /// <value>Get y Set del atributo costoOperativo</value>
        [Range(1, float.MaxValue, ErrorMessage = "No se admiten valores menores a 1")]
        public float costoOperativo { get; set; }

        /// <value>Get y Set del atributo recargaCombustible</value>
        public bool recargaCombustible { get; set; }

        /// <value>Get y Set del atributo comentariosLlegada</value>
        public string comentariosLlegada { get; set; }

        /// <value>Get y Set del atributo ConductorNavigation</value>
        [ForeignKey("chofer")]
        public virtual Conductor ConductorNavigation { get; set; }

        /// <value>Get y Set del atributo VehiculoNavigation</value>
        [ForeignKey("vehiculo")]
        public virtual Vehiculo VehiculoNavigation { get; set; }
    }
}
