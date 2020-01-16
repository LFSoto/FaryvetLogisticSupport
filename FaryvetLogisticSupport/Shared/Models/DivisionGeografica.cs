using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FaryvetLogisticSupport.Shared.Models
{
    [Table("FLS_DisionesGeograficas")]
    public class DivisionGeografica
    {
        public DivisionGeografica()
        {
            Facturas = new HashSet<Factura>();
        }
        [Key]
        [Required]
        public int codigoPostal { get; set; }
        [Required]
        public string ubicacion { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
