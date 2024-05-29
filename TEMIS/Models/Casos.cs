using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TEMIS.Models
{
    public class Casos
    {
        [Key]
        [Display(Name = "Código del caso")]
        [Required(ErrorMessage = "El código es obligatorio")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "El código debe tener 6 caracteres")]
        public string ID_Case { get; set; }

        [Display(Name = "Nombre del caso")]
        [Required(ErrorMessage = "El nombre del caso es obligatorios")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "El nombre del caso entre 10 y 50 caracteres")]
        public string Caso_Nombre { get; set; }

        [Display(Name = "Tipo de facturacion")]
        [Required(ErrorMessage = "El tipo de facturacion es obligatorios")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El tipo de facturacion debe tener entre 2 y 50 caracteres")]
        public string Tipo_Facturacion { get; set; }

        [Display(Name = "Precio del caso")]
        [Required(ErrorMessage = "Precio del caso es obligatorio")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "El Precio del caso debe ser ingresado en numeros")]
        public string PrecioCaso { get; set; }
    }
}