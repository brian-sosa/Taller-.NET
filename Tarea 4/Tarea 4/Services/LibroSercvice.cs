using System.Security.Cryptography;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Tarea_4.Models.Libro;

public class LibroService
{
    private readonly Dictionary<int, Libro> libros = new()
    {
        { 1, new Libro( "Cien Años de Soledad", "Gabriel García Márquez", new DateOnly(1967, 5, 30)) },
        { 2, new Libro( "Don Quijote de la Mancha", "Miguel de Cervantes", new DateOnly(1605, 1, 16)) },
        { 3, new Libro( "La Sombra del Viento", "Carlos Ruiz Zafón", new DateOnly(2001, 4, 12)) },
        { 4, new Libro( "El Amor en los Tiempos del Cólera", "Gabriel García Márquez", new DateOnly(1985, 9, 5)) },
        { 5, new Libro( "Ficciones", "Jorge Luis Borges", new DateOnly(1944, 6, 15)) }
    };

    public List<Libro> GetAll() => libros.Values.ToList();
    public void Delete(string id)
    {
        foreach (var lib in libros)
        {
            if (lib.Value.Id.ToString() == id)
            {
                libros.Remove(lib.Key);
                break;
            }
        }
    }
    public void Add(Libro libro)
    {
        var random = new Random();
        libros.Add(random.Next(1, int.MaxValue), libro);
    }

    public Libro GetById(string id) {
        foreach (var lib in libros)
        {
            if (lib.Value.Id.ToString() == id)
            {
                return lib.Value;
            }
        }
        return null;
    }

    public void Update(Libro libro, string id)
    {
        foreach (var lib in libros)
        {
            if (lib.Value.Id.ToString() == id)
            {
                libros[lib.Key] = libro;
                break;
            }
        }
      
    }

    
}