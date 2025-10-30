using System;

public class Ejercicio1
{
    public class RegistroVentas
    {
        private ServicioRegistro _servicioRegistro;
        private ServicioNotificacion _servicioNotificacion;

        public RegistroVentas(ServicioRegistro servicioRegistro, ServicioNotificacion servicioNotificacion)
        {
            _servicioRegistro = servicioRegistro;
            _servicioNotificacion = servicioNotificacion;
        }

        public void ProcesarVenta(string producto, double precio)
        {
            Console.WriteLine($"Procesando venta: {producto}, {precio:C}");

            _servicioRegistro.RegistrarVenta(producto, precio);
            _servicioNotificacion.EnviarNotificacionVenta(producto);
        }
    }

    public class ServicioRegistro
    {
        public void RegistrarVenta(string producto, double precio)
        {
            Console.WriteLine($"Registro: Venta de {producto} por {precio:C}");
        }
    }

    public class ServicioNotificacion
    {
        public void EnviarNotificacionVenta(string producto)
        {
            Console.WriteLine($"Notificación: Se ha vendido {producto}");
        }
    }

    public static void Ejecutar()
    {
        var servicioRegistro = new ServicioRegistro();
        var servicioNotificacion = new ServicioNotificacion();
        var registroVentas = new RegistroVentas(servicioRegistro, servicioNotificacion);

        registroVentas.ProcesarVenta("Laptop", 1500);
    }
}
