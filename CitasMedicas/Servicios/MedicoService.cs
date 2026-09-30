public class MedicoService
{
    private readonly IRepositorio<Medico> _medicos;
    private readonly IRepositorio<Especialidad> _especialidades;

    public MedicoService(IRepositorio<Medico> medicos, IRepositorio<Especialidad> especialidades)
    {
        _medicos = medicos;
        _especialidades = especialidades;
    }

    public Medico Registrar(string nombre, string apellido, string correo)
    {
        var medico = new Medico(nombre, apellido, correo);
        _medicos.Agregar(medico);
        return medico;
    }

    public void AsignarEspecialidad(int medicoId, int especialidadId)
    {
        var medico = _medicos.ObtenerPorId(medicoId);
        Validador.Existe(medico, "Médico");
        Validador.Existe(_especialidades.ObtenerPorId(especialidadId), "Especialidad");
        medico!.AsignarEspecialidad(especialidadId);
        _medicos.Actualizar(medico);
    }
}
