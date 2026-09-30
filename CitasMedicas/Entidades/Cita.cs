public enum EstadoCita
{
    Programada,
    Cancelada
}

public class Cita : Entidad
{
    public int PacienteId { get; }
    public int MedicoId { get; }
    public DateTime FechaHora { get; private set; }
    public EstadoCita Estado { get; private set; } = EstadoCita.Programada;

    public Cita(int pacienteId, int medicoId, DateTime fechaHora)
    {
        PacienteId = pacienteId;
        MedicoId = medicoId;
        FechaHora = fechaHora;
    }

    public void Cancelar()
    {
        if (Estado == EstadoCita.Cancelada)
            throw new InvalidOperationException("La cita ya está cancelada.");
        Estado = EstadoCita.Cancelada;
    }

    public void Reprogramar(DateTime nuevaFecha)
    {
        if (Estado == EstadoCita.Cancelada)
            throw new InvalidOperationException("No se puede reprogramar una cita cancelada.");
        FechaHora = nuevaFecha;
    }
}
