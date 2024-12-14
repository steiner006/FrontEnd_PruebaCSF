using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaCSF_FrontEnd.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public int AnioPublicacion { get; set; }
        public string Autores { get; set; }
    }
}