using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElBodegon.Models
{
    public class MenuViewModel
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Platillo")]
        public string NombreP { get; set; }
        
        public int Precio  { get; set; }
        public string Tipo { get; set; }

        public string Imagen { get; set; }
    }
}
