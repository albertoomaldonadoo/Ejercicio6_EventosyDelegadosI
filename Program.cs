using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Menú de Ejercicios - Alberto Maldonado Triana 2ºDAM");
            Console.WriteLine();
            Console.WriteLine("1. Ejercicio 1: Registro y Notificación de Ventas");
            Console.WriteLine("2. Ejercicio 2: Control de Temperatura");
            Console.WriteLine("3. Ejercicio 3: Backup y Notificación de Archivos");
            Console.WriteLine("4. Ejercicio 4: Monitoreo de Sensores");
            Console.WriteLine("5. Ejercicio 5: Supervisión de Consumo de Energía");
            Console.WriteLine("-. Salir");
            Console.WriteLine();
            Console.Write("Selecciona un ejercicio: ");
            string opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1": 
                    Ejercicio1.Ejecutar();
                    break;
                case "2": 
                    Ejercicio2.Ejecutar();
                    break;
                case "3": 
                    Ejercicio3.Ejecutar();
                    break;
                case "4": 
                    Ejercicio4.Ejecutar();
                    break;
                case "5":
                    Ejercicio5.Ejecutar();
                    break;
                case "-": 
                    return;
                default: 
                    Console.WriteLine("Opción no valida.");
                    break;
            }
        }
    }
}
