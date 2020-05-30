using System;
using System.Collections.Generic;
using System.Text;

namespace FaryvetLogisticSupport.Shared.Models
{
    /// <summary>
    /// Clase Reporte.
    /// Modelo para el manejo de Reporte en la aplicación.
    /// </summary>
    public class Reporte
    {
        /// <value>Get y Set del atributo chofer</value>
        public string chofer { get; set; }

        /// <value>Get y Set del atributo peso</value>
        public float peso { get; set; }

        /// <value>Get y Set del atributo costo</value>
        public float costo { get; set; }

        /// <value>Get y Set del atributo kilometrajeRecorrido</value>
        public float kilometrajeRecorrido { get; set; }

        /// <value>Get y Set del atributo cantidadEntregas</value>
        public int cantidadEntregas { get; set; }
    }
}
