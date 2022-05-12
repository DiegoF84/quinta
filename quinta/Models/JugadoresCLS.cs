using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace quinta.Models
{
    public class JugadoresCLS
    {
        public int id { get; set; }

        [DisplayName("NOMBRE")]
        [Required]
        [StringLength(20)]
        public string nombre { get; set; }
        
        [DisplayName("APELLIDO")]
        [Required]
        [StringLength(20)]
        public string apellido { get; set; }
        
    }
}