public class NotificadorCorreo : INotificador
{
    public void Enviar(Paciente destinatario, string mensaje)
        => Console.WriteLine($"[CORREO] Para: {destinatario.Correo} | {mensaje}");
}
