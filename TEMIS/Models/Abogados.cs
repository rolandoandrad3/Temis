using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TEMIS.Models
{
    public class Abogados
    {
        // definir propiedades -> atributos de la tabla "Abogados"
        [Key]
        [Display(Name = "Código Abogado")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID_Abogados { get; set; }

        [Display(Name = "Nombre del Abogado")]
        [Required(ErrorMessage = "Los nombres son obligatorios")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Los nombres deben tener entre 3 y 50 caracteres")]
        public string NombreAbogado { get; set; }

        [Display(Name = "Apellido del Abogado")]
        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Los apellidos deben tener entre 3 y 50 caracteres")]
        public string ApellidosAbogado { get; set; }

        [Display(Name = "No. DUI")]
        [Required(ErrorMessage = "El DUI es obligatorio")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "El DUI debe tener 10 caracteres")]
        public string DUIAbogado { get; set; }

        [Display(Name = "Especialidad del Abogado")]
        [Required(ErrorMessage = "La especialidad es obligatoria")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "La especialidad debe tener entre 5 y 20 caracteres")]
        public string EspecialidadAbogado { get; set; }

        [Display(Name = "Numero de Telefono")]
        [Required(ErrorMessage = "El telefono es obligatorio")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "El telefono debe tener entre 8 y 15 caracteres")]
        public string TelefonoAbogado { get; set; }

        [Display(Name = "Email del Abogado")]
        [Required(ErrorMessage = "El Correo Electronico es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El Correo Electronico deben tener entre 3 y 50 caracteres")]
        public string EmailAbogado { get; set; }

        [Display(Name = "Código de Corte Suprema de Justicia")]
        [Required(ErrorMessage = "El codigo de la CSJ (Corte Suprema de Justicia) es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El CSJ debe tener entre 3 y 50 caracteres")]
        public string CSJ { get; set; }
    }
}