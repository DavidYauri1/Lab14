using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Framework_Core.Models
{
    public class Book
    {
     
        public int BookID { get; set; }
        public string Titulo { get; set; }
        public string Author { get; set; }
        public DateTime Fecha { get; set; } 
        public double Precio { get; set; }
        public Boolean Disponible { get; set; }
    }
}
