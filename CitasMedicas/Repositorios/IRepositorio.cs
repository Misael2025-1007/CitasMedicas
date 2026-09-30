public interface IRepositorio<T> where T : Entidad
{
    void Agregar(T item);
    T? ObtenerPorId(int id);
    void Actualizar(T item);
}

public interface ICitaRepositorio : IRepositorio<Cita>
{
    IEnumerable<Cita> ObtenerPorPaciente(int pacienteId);
    IEnumerable<Cita> ObtenerPorMedico(int medicoId);
    bool ExisteConflicto(int medicoId, DateTime fecha);
}
