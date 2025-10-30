using System;

public class Ejercicio3
{
    public class BackupEventArgs : EventArgs
    {
        public string Archivo { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class GestorBackups
    {
        public event EventHandler<BackupEventArgs> BackupCompletado;

        public void HacerBackup(string archivo)
        {
            Console.WriteLine($"Respaldando {archivo}");

            if (BackupCompletado != null)
            {
                foreach (EventHandler<BackupEventArgs> handler in BackupCompletado.GetInvocationList())
                {
                    handler(this, new BackupEventArgs { Archivo = archivo, Fecha = DateTime.Now });
                }
            }
        }
    }

    public class ServicioNotificacion
    {
        public void NotificarBackup(object sender, BackupEventArgs e)
        {
            Console.WriteLine($"Notificación: Backup completado de {e.Archivo}");
        }
    }

    public class ServicioLog
    {
        public void RegistrarBackup(object sender, BackupEventArgs e)
        {
            Console.WriteLine($"Log: {e.Archivo} respaldado a las {e.Fecha}");
        }
    }

    public static void Ejecutar()
    {
        var gestor = new GestorBackups();
        var notificacion = new ServicioNotificacion();
        var log = new ServicioLog();

        gestor.BackupCompletado += notificacion.NotificarBackup;
        gestor.BackupCompletado += log.RegistrarBackup;

        gestor.HacerBackup("documento.txt");
    }
}
