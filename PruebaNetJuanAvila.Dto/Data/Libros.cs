namespace PruebaNetJuanAvila.Dto.Data
{
    public partial class Libros
    {
        public int Isbn { get; set; }
        public int EditorialesId { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public int? NPaginas { get; set; }

        public virtual Editoriales Editoriales { get; set; }
    }
}
