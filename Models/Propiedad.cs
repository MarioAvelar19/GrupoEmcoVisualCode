using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class Propiedad
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(100)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(100)]
        [Display(Name = "Tipo de Propiedad")]
        public string TipoPropiedad { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(100)]
        [Display(Name = "Tipo de Operación")]
        public string TipoOperacion { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Precio")]
        public int Precio { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Cantidad baños")]
        public int Baños { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Cantidad cuartos")]
        public int Cuartos { get; set; }


    }
}
