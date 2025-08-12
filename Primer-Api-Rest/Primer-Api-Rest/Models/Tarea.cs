namespace Primer_Api_Rest.Models;


public class Tarea
{
    public int _Id { get; set; }
    public String? _Nombre { get; set; }
    public String? _Descripcion { get; set; }
   

    public int? _Duracion { get; set; }
    public String? _Responsable { get; set; }


    public Tarea(int _Id, String _Nombre, String _Descripcion, int _Duracion, String _Responsable)
    {
        this._Id = _Id;
        this._Nombre = _Nombre;
        this._Descripcion = _Descripcion;
        this._Duracion = _Duracion;
        this._Responsable = _Responsable;
    }


    public Tarea() { }
    

}