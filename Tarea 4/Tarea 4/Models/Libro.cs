namespace Tarea_4.Models.Libro
{
    public class Libro
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }

        public DateOnly FechaPublicacion { get; set; }

        public Libro(string titulo, string autor, DateOnly fechaPublicacion)
        {
            Id = Guid.NewGuid();
            Titulo = titulo;
            Autor = autor;
            FechaPublicacion = fechaPublicacion;
        }

        public Libro()
        {
        Id = Guid.NewGuid();
    }
}
}