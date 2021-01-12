using PruebaNetJuanAvila.Dto.Data;
using System.Collections.Generic;

namespace PruebaNetJuanAvila.Dto.Dto
{
    public class LibrosDto:Libros
    {
        public string EditorialName { get; set; }
        public List<int> Autores { get; set; }
        public string AutoresName { get; set; }
    }
}
