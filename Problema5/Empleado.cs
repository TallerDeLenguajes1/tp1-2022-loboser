// See https://aka.ms/new-console-template for more information

namespace Problema4
{
    public class DatosPersonales{
        string nombre = "", apellido = "";
        DateTime fechaDeNacimiento;
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
    }
    public class DatosProfesionales
    {
        DateTime fechaDeIngreso;
        float sueldoBasico;
        public DateTime FechaDeIngreso { get => fechaDeIngreso; set => fechaDeIngreso = value; }
        public float SueldoBasico { get => sueldoBasico; set => sueldoBasico = value; }
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
                adicional = Antiguedad()/100;
            }
            
            return datosProfesionales.SueldoBasico + datosProfesionales.SueldoBasico*Antiguedad() - datosProfesionales.SueldoBasico*0.15;
        }
    }
}