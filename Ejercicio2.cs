using System;

public class Ejercicio2
{
    public class TemperaturaEventArgs : EventArgs
    {
        public double Temperatura { get; set; }
        public double Umbral { get; set; }
    }

    public class ControlTemperatura
    {
        public event EventHandler<TemperaturaEventArgs> TemperaturaAlta;

        public void RevisarTemperatura(double temperatura, double umbral)
        {
            Console.WriteLine($"Temperatura actual: {temperatura}°C");
            if (temperatura > umbral)
            {
                var handler = TemperaturaAlta;
                if (handler != null)
                {
                    handler(this, new TemperaturaEventArgs { Temperatura = temperatura, Umbral = umbral });
                }
            }
        }
    }

    public class ServicioAlerta
    {
        public void EnviarAlerta(object sender, TemperaturaEventArgs evento)
        {
            Console.WriteLine($"Alerta: Temperatura {evento.Temperatura}°C supera el umbral de {evento.Umbral}°C");
        }
    }

    public class ServicioRegistroTemperatura
    {
        public void RegistrarTemperatura(object sender, TemperaturaEventArgs evento)
        {
            Console.WriteLine($"Registro: Temperatura registrada {evento.Temperatura}°C");
        }
    }

    public static void Ejecutar()
    {
        var control = new ControlTemperatura();
        var alerta = new ServicioAlerta();
        var registro = new ServicioRegistroTemperatura();

        control.TemperaturaAlta += alerta.EnviarAlerta;
        control.TemperaturaAlta += registro.RegistrarTemperatura;

        control.RevisarTemperatura(35, 30);
    }
}
