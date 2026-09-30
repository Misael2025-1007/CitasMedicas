public class Medico : Entidad
{
    public string Nombre { get; }
    public string Apellido { get; }
    public string Correo { get; }
    public int? EspecialidadId { get; private set; }

    public Medico(string nombre, string apellido, string correo)
    {
        Validador.NoVacio(nombre, "Nombre");
        Validador.NoVacio(apellido, "Apellido");
        Validador.NoVacio(correo, "Correo");
        Nombre = nombre;
        Apellido = apellido;
        Correo = correo;
    }

    public void AsignarEspecialidad(int especialidadId)
    {
        EspecialidadId = especialidadId;
    }
}
