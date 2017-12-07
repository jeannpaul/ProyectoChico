using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoChico.ViewModels
{
    public class ContactView
    {
        [Required]
        [MinLength(5,ErrorMessage ="Minimo 5 caracteres en nombre")]
        public string nombre { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Email invalido")]
        public string email { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Maximo 50 caracteres en contenido")]
        public string contenido { get; set; }
    }
}
