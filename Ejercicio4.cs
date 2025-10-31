using System;

public class Ejercicio4
{
    public class IntrusoEventArgs : EventArgs
    {
        public string Sensor { get; set; }
        public DateTime Hora { get; set; }
    }

    public class SensorMonitoreo
    {
        public event EventHandler<IntrusoEventArgs> AlertaIntruso;

        public void RevisarSensor(string sensor, DateTime hora, int horaPermitida)
        {
            Console.WriteLine($"Revisando {sensor} a las {hora.Hour}h");
            if (hora.Hour > horaPermitida && AlertaIntruso != null)
            {
                foreach (EventHandler<IntrusoEventArgs> handler in AlertaIntruso.GetInvocationList())
                {
                    handler(this, new IntrusoEventArgs { Sensor = sensor, Hora = hora });
                }
            }
        }
    }

    public class ServicioAlarma
    {
        public void ActivarAlarma(object sender, IntrusoEventArgs evento)
        {
            Console.WriteLine($"Alarma: {evento.Sensor} detectado fuera de horario a las {evento.Hora}");
        }
    }

    public class ServicioRegistroIncidencias
    {
        public void RegistrarIncidencia(object sender, IntrusoEventArgs evento)
        {
            Console.WriteLine($"Registro: Incidencia en {evento.Sensor} a las {evento.Hora}");
        }
    }

    public static void Ejecutar()
    {
        var sensor = new SensorMonitoreo();
        var alarma = new ServicioAlarma();
        var registro = new ServicioRegistroIncidencias();

        sensor.AlertaIntruso += alarma.ActivarAlarma;
        sensor.AlertaIntruso += registro.RegistrarIncidencia;

        sensor.RevisarSensor("PuertaPrincipal", DateTime.Now, 22);
    }
}
