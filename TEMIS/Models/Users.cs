using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TEMIS.Models
{
    public class Users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nombre de Usuario (CSJ)")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El CSJ debe tener entre 3 y 50 caracteres")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La contraseña deben tener entre 3 y 50 caracteres")]
        public string Contraseña { get; set; }
    }
}