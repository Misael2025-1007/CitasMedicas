public class PacienteService
{
    private readonly IRepositorio<Paciente> _repo;

    public PacienteService(IRepositorio<Paciente> repo)
    {
        _repo = repo;
    }

    public Paciente Registrar(string nombre, string apellido, string telefono, string correo)
    {
        var paciente = new Paciente(nombre, apellido, telefono, correo);
        _repo.Agregar(paciente);
        return paciente;
    }
}
