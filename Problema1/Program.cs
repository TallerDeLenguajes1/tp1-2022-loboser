// See https://aka.ms/new-console-template for more information
using System;

namespace Problema1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            Console.WriteLine("Ingresar un numero: ");
            try
            {
                num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(num*num);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error de formato (" + ex.Message + ")");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Error de desbordamiento (" + ex.Message + ")");
            }

            Console.ReadLine();
        }
    }
}
