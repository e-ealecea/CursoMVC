using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //Nos permite hacer validaciones por medio de []

namespace cursoNET.Models.ViewModel
{
    //Clase que se necesitará para ingresar datos
    public class UserViewModel
    {
        [Required]
        [EmailAddress] //Validación
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 4)]
        [Display(Name = "Correo electrónico")] //??
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)] //Irá de una forma incriptada
        public string Password { get; set; }

        [Display(Name = "Confirmar contraseña")]
        [DataType(DataType.Password)] //Irá de una forma incriptada
        [Compare("Password", ErrorMessage ="Las contraseñas no coinciden")] //1er parametro es el nombre del atributo

        public string ConfirmPassword { get; set; }
        [Required]
        public int Edad { get; set; }

    }

    //Clase para editar
    public class EditUserViewModel
    {
        public int Id { get; set; }
        
        [Required]
        [EmailAddress] //Validación
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 4)]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)] 
        public string Password { get; set; }

        [Display(Name = "Confirmar contraseña")]
        [DataType(DataType.Password)] 
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]

        public string ConfirmPassword { get; set; }
        [Required]
        public int Edad { get; set; }

    }
}