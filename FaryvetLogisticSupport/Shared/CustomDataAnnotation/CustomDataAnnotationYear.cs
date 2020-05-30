using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FaryvetLogisticSupport.Shared.CustomDataAnnotation
{
    /// <summary>
    /// Clase CustomDataAnnotationYear.
    /// Modelo para el manejo de excepciones en el año del vehiculo en la aplicación.
    /// </summary>
    public class CustomDataAnnotationYear : RangeAttribute
    {
        /// <summary>
        /// Constructor de la clase Vehiculo
        /// Verifica que el año sea mayor o igual a 1970 y menor o igual al año + 1.
        /// </summary>
        public CustomDataAnnotationYear() : base(1970, DateTime.Now.Year + 1)
        {

        }
    }
}
