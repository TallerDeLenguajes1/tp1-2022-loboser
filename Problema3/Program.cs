// See https://aka.ms/new-console-template for more information
using System;
using NLog;

namespace Problema3
{
    class Program
    {
        static void Main(string[] args)
        {
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

            double kilometros,litros;
            try
            {
                Console.Write("Ingresar kilometros recorridos: ");
                kilometros = Convert.ToDouble(Console.ReadLine());

                logger.Trace($"Se Ingresó {kilometros} como cantidad de kilometros");

                Console.Write("Ingresar litros consumidos: ");
                litros = Convert.ToDouble(Console.ReadLine());
                
                logger.Trace($"Se Ingresó {litros} como cantidad de litros consumidos");


                if (kilometros<0 || litros<0)
                {
                    throw new NegativeException();
                }

                double resultado = kilometros/litros;

                logger.Trace($"Se realizo el calculo dando {resultado} como resultado");


                if (resultado == double.NegativeInfinity || resultado == double.PositiveInfinity)
                {
                    throw new InfinityException("Numero demasiado grande");
                }

                Console.WriteLine("Kilometros recorridos por litros consumidos: " + resultado);

                logger.Info("Se escribio por consola el resultado anterior");

            }
            catch(InfinityException ex){
                Console.WriteLine("Error numero infinito (" + ex.Message + ")");
            }
            catch(NegativeException){
                Console.WriteLine("Error de numero negativo");
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
    public class InfinityException : Exception
        {
        public InfinityException()
        {
        }
        public InfinityException(string message)
        : base(message)
        {
        }
    }

    public class NegativeException : Exception
        {
        public NegativeException()
        {
        }
    }
}
