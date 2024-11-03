using System;
using BoletoNamespace;
using ColectivoNamespace;
using TarjetaNamespace;

class Program
{
    public static void Main(string[] args)
    {
        Boleto boleto = new Boleto();
        Colectivo colectivo = new Colectivo();
        Tarjeta tarjeta = null;

        while (true)
        {
            Console.WriteLine("Tipo de tarjeta a usar: ");
            Console.WriteLine("1 Normal");
            Console.WriteLine("2 Medio Boleto");
            Console.WriteLine("3 Franquicia Completa");
            string tipo_tarjeta = Console.ReadLine();

            switch (tipo_tarjeta)
            {
                case "1":
                    tarjeta = new Tarjeta();
                    break;
                case "2":
                    tarjeta = new MedioBoleto();
                    break;
                case "3":
                    tarjeta = new FranquiciaCompleta();
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    continue; // Volver a pedir el tipo de tarjeta
            }
            break; // Salir del ciclo al seleccionar una tarjeta
        }

        while (true)
        {
            Console.WriteLine("Ingrese una opcion");
            Console.WriteLine("1: Cargar saldo");
            Console.WriteLine("2: Pagar boleto");
            Console.WriteLine("Saldo actual: " + tarjeta.saldo);

            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Ingrese el monto a cargar");
                    int monto = int.Parse(Console.ReadLine());
                    tarjeta.cargarSaldo(monto);
                    break;

                case "2":
                    // Verificar si la tarjeta tiene usos y limitaciones de franquicia
                    if (tarjeta.TarjetaUsos(tarjeta) && tarjeta.LimitacionFranquicia(tarjeta))
                    {
                        colectivo.PagarCon(tarjeta, tarjeta.precioBoleto(boleto.precio));
                    }
                    else
                    {
                        colectivo.PagarCon(tarjeta, boleto.precio);
                    }

                    // Mostrar detalles del boleto
                    boleto.FechaDatos();
                    boleto.TipoTarjeta(tarjeta);
                    boleto.MostrarLinea(colectivo);
                    break;

                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }
        }
    }
}
