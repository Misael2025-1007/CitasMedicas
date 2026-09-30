public class Paciente : Entidad
{
    public string Nombre { get; }
    public string Apellido { get; }
    public string Telefono { get; }
    public string Correo { get; }

    public Paciente(string nombre, string apellido, string telefono, string correo)
    {
        Validador.NoVacio(nombre, "Nombre");
        Validador.NoVacio(apellido, "Apellido");
        Validador.NoVacio(telefono, "Teléfono");
        Validador.NoVacio(correo, "Correo");
        Nombre = nombre;
        Apellido = apellido;
        Telefono = telefono;
        Correo = correo;
    }
}
