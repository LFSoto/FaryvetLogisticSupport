using System;
using System.Collections.Generic;
using System.Text;

namespace FaryvetLogisticSupport.Shared.Models
{
    public class Reporte
    {
        public string chofer { get; set; }
        public float peso { get; set; }
        public float costo { get; set; }
        public float kilometrajeRecorrido { get; set; }
        public int cantidadEntregas { get; set; }
    }
}
