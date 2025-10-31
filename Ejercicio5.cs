using System;

public class Ejercicio5
{
    public class EnergiaEventArgs : EventArgs
    {
        public double Consumo { get; set; }
        public double Umbral { get; set; }
    }

    public class MonitorEnergia
    {
        public Action<object, EnergiaEventArgs> ConsumoExcesivoDetectado;

        public void RevisarConsumo(double consumo, double umbral)
        {
            Console.WriteLine($"Consumo actual: {consumo} kWh");
            if (consumo > umbral && ConsumoExcesivoDetectado != null)
            {
                ConsumoExcesivoDetectado(this, new EnergiaEventArgs { Consumo = consumo, Umbral = umbral });
            }
        }
    }

    public class ServicioNotificacion
    {
        public void EnviarAdvertencia(object sender, EnergiaEventArgs evento)
        {
            Console.WriteLine($"Advertencia: Consumo {evento.Consumo} kWh supera umbral {evento.Umbral} kWh");
        }
    }

    public class ServicioAjusteAutomatizado
    {
        public void AjustarDispositivos(object sender, EnergiaEventArgs evento)
        {
            Console.WriteLine("Ajustando dispositivos para reducir consumo...");
        }
    }

    public static void Ejecutar()
    {
        var monitor = new MonitorEnergia();
        var notificacion = new ServicioNotificacion();
        var ajuste = new ServicioAjusteAutomatizado();

        monitor.ConsumoExcesivoDetectado += notificacion.EnviarAdvertencia;
        monitor.ConsumoExcesivoDetectado += ajuste.AjustarDispositivos;

        monitor.RevisarConsumo(120, 100);
    }
}
