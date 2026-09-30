public class EspecialidadService
{
    private readonly IRepositorio<Especialidad> _repo;

    public EspecialidadService(IRepositorio<Especialidad> repo)
    {
        _repo = repo;
    }

    public Especialidad Registrar(string nombre)
    {
        var especialidad = new Especialidad(nombre);
        _repo.Agregar(especialidad);
        return especialidad;
    }
}
