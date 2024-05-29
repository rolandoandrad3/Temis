using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TEMIS.Models
{
    public class Clientes
    {
        // definir propiedades -> atributos de la tabla "Clientes"
        [Key]
        [Display(Name = "Código Cliente")]
        [Required(ErrorMessage = "El código es obligatorio")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "El código debe tener 6 caracteres")]
        public string ID_Cliente { get; set; }

        [Display(Name = "Primer Nombre")]
        [Required(ErrorMessage = "Los nombres son obligatorios")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Los nombres deben tener entre 3 y 50 caracteres")]
        public string PrimNombre { get; set; }

        [Display(Name = "Segundo Nombre")]
        [Required(ErrorMessage = "Los nombres son obligatorios")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Los nombres deben tener entre 3 y 50 caracteres")]
        public string SegNombre { get; set; }

        [Display(Name = "Primer Apellido")]
        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Los apellidos deben tener entre 3 y 50 caracteres")]
        public string PrimAprellido { get; set; }

        [Display(Name = "Segundo Apellido")]
        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Los apellidos deben tener entre 3 y 50 caracteres")]
        public string SegAprellido { get; set; }

        [Display(Name = "No. DUI")]
        [Required(ErrorMessage = "El DUI es obligatorio")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "El DUI debe tener 10 caracteres")]
        public string DUI { get; set; }

        [Display(Name = "Edad del Cliente")]
        [Required(ErrorMessage = "La edad es obligatoria")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "La edad debe tener entre 1 y 3 caracteres")]
        public string Client_Edad { get; set; }


        [Required(ErrorMessage = "La Nacionalidad es obligatoria")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "La Nacionalidad debe tener entre 5 y 20 caracteres")]
        public string Nacionalidad { get; set; }

        [Required(ErrorMessage = "La Ocupacion es obligatoria")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "La Ocupacion debe tener entre 5 y 50 caracteres")]
        public string Ocupacion { get; set; }

        [Required(ErrorMessage = "La Direccion es obligatoria")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "La Direccion debe tener entre 5 y 500 caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "El telefono debe tener entre 8 y 15 caracteres")]
        public string Telefonoo { get; set; }

        [Required(ErrorMessage = "El Correo Electronico es obligatorio")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "El Correo Electronico deben tener entre 10 y 50 caracteres")]
        public string Email { get; set; }
    }
}