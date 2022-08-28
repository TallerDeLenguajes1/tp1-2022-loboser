// See https://aka.ms/new-console-template for more information

namespace Problema4
{
    public class DatosPersonales{
        string nombre = "", apellido = "";
        DateTime fechaDeNacimiento;
        string estadoCivil;
        int hijos;
        DateTime fechaDeDivorcio;
        bool tieneTitulo;
        string titulo, universidad;
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
        public string EstadoCivil { get => estadoCivil; set => estadoCivil = value; }
        public int Hijos { get => hijos; set => hijos = value; }
        public DateTime FechaDeDivorcio { get => fechaDeDivorcio; set => fechaDeDivorcio = value; }
        public bool TieneTitulo { get => tieneTitulo; set => tieneTitulo = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Universidad { get => universidad; set => universidad = value; }
    }
    public class DatosProfesionales
    {
        DateTime fechaDeIngreso;
        double sueldoBasico;
        public DateTime FechaDeIngreso { get => fechaDeIngreso; set => fechaDeIngreso = value; }
        public double SueldoBasico { get => sueldoBasico; set => sueldoBasico = value; }
    }
    public class Empleado
    {
        DatosPersonales datosPersonales;
        DatosProfesionales datosProfesionales;
        public DatosPersonales DatosPersonales { get => datosPersonales; set => datosPersonales = value; }
        public DatosProfesionales DatosProfesionales { get => datosProfesionales; set => datosProfesionales = value; }
        public int Edad()
        {
            return DateTime.Today.AddTicks(-datosPersonales.FechaDeNacimiento.Ticks).Year - 1;
        }
        public int Antiguedad()
        {
            return DateTime.Today.AddTicks(-datosProfesionales.FechaDeIngreso.Ticks).Year - 1;
        }
        public double Salario()
        {
            double adicional;
            if(Antiguedad()>=20){
                adicional = 0.25;
            }else
            {
                adicional = Convert.ToDouble(Antiguedad())/100;
            }
            return datosProfesionales.SueldoBasico + datosProfesionales.SueldoBasico*adicional - datosProfesionales.SueldoBasico*0.15;
        }
    }
}