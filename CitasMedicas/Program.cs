var pacientesRepo = new RepositorioEnMemoria<Paciente>();
var medicosRepo = new RepositorioEnMemoria<Medico>();
var especialidadesRepo = new RepositorioEnMemoria<Especialidad>();
var citasRepo = new CitaRepositorioEnMemoria();

var pacienteSrv = new PacienteService(pacientesRepo);
var especialidadSrv = new EspecialidadService(especialidadesRepo);
var medicoSrv = new MedicoService(medicosRepo, especialidadesRepo);
var citaSrv = new CitaService(citasRepo, pacientesRepo, medicosRepo);
var recordatorioSrv = new RecordatorioService(citasRepo, pacientesRepo, new NotificadorCorreo());

var esp = especialidadSrv.Registrar("Cardiología");
var medico = medicoSrv.Registrar("Ana", "Pérez", "ana@clinica.com");
medicoSrv.AsignarEspecialidad(medico.Id, esp.Id);
var paciente = pacienteSrv.Registrar("Misael", "Smith", "809-000-0000", "misael@mail.com");

var fecha = DateTime.Now.AddDays(2);
var cita = citaSrv.Agendar(paciente.Id, medico.Id, fecha);
Console.WriteLine($"Cita {cita.Id} agendada: {cita.FechaHora}");

try { citaSrv.Agendar(paciente.Id, medico.Id, fecha); }
catch (Exception ex) { Console.WriteLine($"Duplicada bloqueada: {ex.Message}"); }

citaSrv.Reprogramar(cita.Id, fecha.AddDays(1));
recordatorioSrv.Enviar(cita.Id);

Console.WriteLine($"Citas del paciente: {citaSrv.ConsultarPorPaciente(paciente.Id).Count()}");
Console.WriteLine($"Citas del médico: {citaSrv.ConsultarPorMedico(medico.Id).Count()}");

citaSrv.Cancelar(cita.Id);
Console.WriteLine($"Estado final: {citasRepo.ObtenerPorId(cita.Id)!.Estado}");
