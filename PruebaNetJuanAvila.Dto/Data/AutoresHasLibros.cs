using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaNetJuanAvila.Dto.Data
{
    public partial class AutoresHasLibros
    {
        public int AutoresId { get; set; }
        public int LibrosIsbn { get; set; }

        public virtual Autores Autores { get; set; }
        public virtual Libros LibrosIsbnNavigation { get; set; }
    }
}
