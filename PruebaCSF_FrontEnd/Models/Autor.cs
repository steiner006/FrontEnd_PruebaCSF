using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaCSF_FrontEnd.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; } 

    }
}