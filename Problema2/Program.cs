// See https://aka.ms/new-console-template for more information
using System;

namespace Problema2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1,num2;
            try
            {
                Console.Write("Ingresar dividendo: ");
                num1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Ingresar divisor: ");
                num2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Resultado: " + num1/num2);
            }
            
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error de division por 0 (" + ex.Message + ")");
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
