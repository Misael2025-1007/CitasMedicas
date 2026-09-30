public static class Validador
{
    public static void NoVacio(string valor, string campo)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException($"{campo} es obligatorio.");
    }

    public static void FechaFutura(DateTime fecha)
    {
        if (fecha <= DateTime.Now)
            throw new ArgumentException("La fecha debe ser futura.");
    }

    public static void Existe(object? entidad, string nombre)
    {
        if (entidad is null)
            throw new InvalidOperationException($"{nombre} no existe.");
    }
}
