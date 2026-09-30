public class RepositorioEnMemoria<T> : IRepositorio<T> where T : Entidad
{
    protected readonly List<T> Items = new();
    private int _siguienteId = 1;

    public void Agregar(T item)
    {
        item.Id = _siguienteId++;
        Items.Add(item);
    }

    public T? ObtenerPorId(int id) => Items.FirstOrDefault(i => i.Id == id);

    public void Actualizar(T item)
    {
        // En memoria la referencia ya está actualizada
    }
}
