public class Especialidad : Entidad
{
    public string Nombre { get; }

    public Especialidad(string nombre)
    {
        Validador.NoVacio(nombre, "Nombre");
        Nombre = nombre;
    }
}
