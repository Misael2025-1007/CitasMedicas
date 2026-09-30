public class CitaRepositorioEnMemoria : RepositorioEnMemoria<Cita>, ICitaRepositorio
{
    public IEnumerable<Cita> ObtenerPorPaciente(int pacienteId)
        => Items.Where(c => c.PacienteId == pacienteId);

    public IEnumerable<Cita> ObtenerPorMedico(int medicoId)
        => Items.Where(c => c.MedicoId == medicoId);

    public bool ExisteConflicto(int medicoId, DateTime fecha)
        => Items.Any(c => c.MedicoId == medicoId
                       && c.FechaHora == fecha
                       && c.Estado == EstadoCita.Programada);
}
