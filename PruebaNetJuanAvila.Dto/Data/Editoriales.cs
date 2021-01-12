﻿using System.Collections.Generic;

namespace PruebaNetJuanAvila.Dto.Data
{
    public partial class Editoriales
    {
        public Editoriales()
        {
            Libros = new HashSet<Libros>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sede { get; set; }

        public virtual ICollection<Libros> Libros { get; set; }
    }
}
