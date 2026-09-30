public class RecordatorioService
{
    private readonly ICitaRepositorio _citas;
    private readonly IRepositorio<Paciente> _pacientes;
    private readonly INotificador _notificador;

    public RecordatorioService(ICitaRepositorio citas, IRepositorio<Paciente> pacientes, INotificador notificador)
    {
        _citas = citas;
        _pacientes = pacientes;
        _notificador = notificador;
    }

    public void Enviar(int citaId)
    {
        var cita = _citas.ObtenerPorId(citaId);
        Validador.Existe(cita, "Cita");
        var paciente = _pacientes.ObtenerPorId(cita!.PacienteId)!;
        _notificador.Enviar(paciente, $"Recordatorio: cita el {cita.FechaHora:dd/MM/yyyy HH:mm}");
    }
}
