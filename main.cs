using System;
using BoletoNamespace;
using ColectivoNamespace;
using TarjetaNamespace;

class main
{

    public static void Main(string[] args)
    {
        Tarjeta tarjeta = new Tarjeta();
        Boleto boleto = new Boleto();
        Colectivo colectivo = new Colectivo();

        while (true)
        {
            Console.WriteLine("Ingrese una opcion");
            Console.WriteLine("1: Cargar saldo");
            Console.WriteLine("2: Pagar boleto");

            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Ingrese el monto a cargar");
                    int monto = int.Parse(Console.ReadLine());
                    tarjeta.cargarSaldo(monto);
                    break;
                case "2":
                    colectivo.PagarCon(tarjeta);
                    Console.WriteLine($"Saldo actual: {tarjeta.saldo}");

                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }
        }
    }
}