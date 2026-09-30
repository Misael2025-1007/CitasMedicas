public class CitaService
{
    private readonly ICitaRepositorio _citas;
    private readonly IRepositorio<Paciente> _pacientes;
    private readonly IRepositorio<Medico> _medicos;

    public CitaService(ICitaRepositorio citas, IRepositorio<Paciente> pacientes, IRepositorio<Medico> medicos)
    {
        _citas = citas;
        _pacientes = pacientes;
        _medicos = medicos;
    }

    public Cita Agendar(int pacienteId, int medicoId, DateTime fecha)
    {
        Validador.Existe(_pacientes.ObtenerPorId(pacienteId), "Paciente");
        Validador.Existe(_medicos.ObtenerPorId(medicoId), "Médico");
        ValidarDisponibilidad(medicoId, fecha);

        var cita = new Cita(pacienteId, medicoId, fecha);
        _citas.Agregar(cita);
        return cita;
    }

    public void Reprogramar(int citaId, DateTime nuevaFecha)
    {
        var cita = _citas.ObtenerPorId(citaId);
        Validador.Existe(cita, "Cita");
        ValidarDisponibilidad(cita!.MedicoId, nuevaFecha);
        cita.Reprogramar(nuevaFecha);
        _citas.Actualizar(cita);
    }

    public void Cancelar(int citaId)
    {
        var cita = _citas.ObtenerPorId(citaId);
        Validador.Existe(cita, "Cita");
        cita!.Cancelar();
        _citas.Actualizar(cita);
    }

    public IEnumerable<Cita> ConsultarPorPaciente(int pacienteId)
        => _citas.ObtenerPorPaciente(pacienteId);

    public IEnumerable<Cita> ConsultarPorMedico(int medicoId)
        => _citas.ObtenerPorMedico(medicoId);

    private void ValidarDisponibilidad(int medicoId, DateTime fecha)
    {
        Validador.FechaFutura(fecha);
        if (_citas.ExisteConflicto(medicoId, fecha))
            throw new InvalidOperationException("El médico no está disponible en esa fecha.");
    }
}
