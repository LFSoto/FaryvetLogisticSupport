using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FaryvetLogisticSupport.Shared.CustomDataAnnotation
{
    /// <summary>
    /// Clase CustomDataAnnotationDate.
    /// Modelo para el manejo de excepciones de fecha en la aplicación.
    /// </summary>
    public class CustomDataAnnotationDate : ValidationAttribute
    {
        /// <summary>
        /// Este metodo verifica si la fecha que le llega en value es menor o igual a la fecha actual.
        /// </summary>
        /// <param name="value">campo de tipo object</param>
        /// <param name="validationContext">campo de tipo ValidationContext</param>
        /// <returns>retorna un objeto de tipo ValidationResult con el valor Success si es verdadero, en caso contrario retorna un mensaje de error</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dt = (DateTime)value;
            if (dt <= DateTime.UtcNow)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "Fecha no valida");
        }
    }
}
