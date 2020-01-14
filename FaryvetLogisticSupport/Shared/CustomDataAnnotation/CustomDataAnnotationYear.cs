using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FaryvetLogisticSupport.Shared.CustomDataAnnotation
{
    public class CustomDataAnnotationYear : RangeAttribute
    {
        public CustomDataAnnotationYear() : base(1970, DateTime.Now.Year + 1)
        {

        }
    }
}
