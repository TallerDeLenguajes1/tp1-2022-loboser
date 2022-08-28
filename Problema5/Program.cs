// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Net;
using System.IO;

namespace Problema4
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Cantidad de Empleados a Generar: ");
            int n = Convert.ToInt32(Console.ReadLine());
            List<Empleado> ListaDeEmpleados = new List<Empleado>();
             
            for (int i = 0; i < n; i++)
            {
                ListaDeEmpleados.Add(GenerarEmpleadoAleatorio());
            }
            int j = 1;
            foreach (var empleado in ListaDeEmpleados)
            {
                Console.WriteLine($"{j} {empleado.DatosPersonales.Apellido} {empleado.DatosPersonales.Nombre}");
                Console.WriteLine($"{empleado.Edad()} años de edad");
                Console.WriteLine($"{empleado.Antiguedad()} años en la empresa");
                Console.WriteLine($"Salario: ${empleado.Salario()}");
                Console.WriteLine("");

                j++;
            }
        }
        public static int DiaAleatorio(int anio, int mes){
            int dia = 0, aux = 0;
            switch (mes)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    aux = 1; break;
                case 4:
                case 6:
                case 9:
                case 11:
                    aux = 2; break;
                case 2:
                    if (DateTime.IsLeapYear(anio))
                    {
                        aux = 3;
                    }
                    else
                    {
                        aux = 4;
                    }
                    break;
            }

            switch (aux)
            {
                case 1: dia = new Random().Next(1, 32); break;
                case 2: dia = new Random().Next(1, 31); break;
                case 3: dia = new Random().Next(1, 30); break;
                case 4: dia = new Random().Next(1, 29); break;
            }
            return dia;
        }

        public static DateTime GenerarFechaDeNacimientoAleatoria()
        {

            int anio = new Random().Next(DateTime.Today.Year-65, DateTime.Today.Year-24);
            int mes = new Random().Next(1,13);
            int dia = DiaAleatorio(anio, mes);

            return new DateTime(anio, mes, dia);
        }

        public static DateTime GenerarFechaAleatoria(int anioDeNacimiento)
        {
            int anio = new Random().Next(anioDeNacimiento+18, DateTime.Today.Year);
            int mes = new Random().Next(1,13);
            int dia = DiaAleatorio(anio, mes);

            return new DateTime(anio, mes, dia);
        }
        public static DatosPersonales GenerarDatosPersonalesAleatorios(){
            var rdn = new Random();
            var datosPersonales = new DatosPersonales();

            string[] nombres = {"Pedro", "Pepe", "Jose", "Emanuel", "Matias", "Martin", "Maxi", "Alejandro", "Hernando", "Fernando", "Nicolas", "Fausto", "Dylan", "Sergio", "Zair"};
            string[] apellidos = {"Lobo", "Peralta", "Juarez", "Fernandez", "Herrera", "Sandoval", "Servantes", "Serantes", "Cordoba", "Ybañez", "Guarnizo", "Moya", "Martinez", "Amado", "Ruiz"};
            string[] estadoCivil = {"Soltero", "Casado", "Divorciado", "Viudo"};
            string[] titulos = {"Programador Universitario", "Licenciado en Informatica", "Ingeniero en Informatica", "Ingeniero en Computacion"};


            datosPersonales.Nombre = nombres[rdn.Next(15)];
            datosPersonales.Apellido = apellidos[rdn.Next(15)];
            datosPersonales.FechaDeNacimiento = GenerarFechaDeNacimientoAleatoria();
            datosPersonales.Hijos = rdn.Next(8);
            datosPersonales.EstadoCivil = estadoCivil[rdn.Next(4)];
            if(datosPersonales.EstadoCivil == "Divorciado"){
                datosPersonales.FechaDeDivorcio = GenerarFechaAleatoria(datosPersonales.FechaDeNacimiento.Year);
            }else
            {
                datosPersonales.FechaDeDivorcio = new DateTime(1,1,1);
            }

            datosPersonales.TieneTitulo = Convert.ToBoolean(rdn.Next(2));
            if (datosPersonales.TieneTitulo)
            {
                datosPersonales.Titulo = titulos[rdn.Next(4)];
                datosPersonales.Universidad = "Universidad Nacional de Tucuman";
            }

            return datosPersonales;
        }
        public static DatosProfesionales GenerarDatosProfesionalesAleatorios(int anioDeNacimiento){
            var rdn = new Random();
            var datosProfesionales = new DatosProfesionales();
            datosProfesionales.FechaDeIngreso = GenerarFechaAleatoria(anioDeNacimiento);

            var sueldo = rdn.Next(100000,180001);
            datosProfesionales.SueldoBasico = sueldo-sueldo%1000;

            return datosProfesionales;
        }
        public static Empleado GenerarEmpleadoAleatorio(){
            var empleado = new Empleado();
            try
            {
                empleado.DatosPersonales = GenerarDatosPersonalesAleatorios();
                empleado.DatosProfesionales = GenerarDatosProfesionalesAleatorios(empleado.DatosPersonales.FechaDeNacimiento.Year);
            }
            catch (System.Exception)
            {
                Console.WriteLine("Error en la Generacion de el Empleado");
            }
            
            return empleado;
        }
    }
}