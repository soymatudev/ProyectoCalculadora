using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCalculadora
{
    internal class Calculadora
    {
        private int longitud;
        private int opci = 0;
        private string username;
        private static Funciones Funciones = new Funciones();
        private static Log Log = null;
        private string[] arropci = {"Sumar", "Restar", "Multiplicar", "Dividir"};

        public Calculadora(int opci, string username)
        {
            this.opci = opci;
            this.username = username;
            Log = new Log(username);
            initMessage();
            init();
        }

        public void init()
        {
            double result = 0;
            switch (this.opci)
            {
                case 1:
                    result = Sumar(loopData());
                    break;
                case 2:
                    result = Restar(loopData());
                    break;
                case 3:
                    result = Multiplicar(loopData());
                    break;
                case 4:
                    result = Dividir(loopData());
                    break;
            }
            Console.WriteLine($"El resultado de la operacion {arropci[this.opci - 1]} es: {result}");
            Log.WriteLog($"El resultado de la operacion {arropci[this.opci - 1]} es: {result}", arropci[this.opci - 1]);
        }

        public void initMessage()
        {      
            if (this.opci != 4)
            {
                Console.WriteLine("Ingrese con cuantos numeros desea operar: ");
                this.longitud = Funciones.numVal(int.MinValue, int.MaxValue);
            } else
            {
                Console.WriteLine("En la division solo se pueden ingresar 2 numeros");
                this.longitud = 2;
            }
        }

        public double[] loopData()
        {

            double[] data = new double[this.longitud];
            for (int i = 0; i < this.longitud; i++)
            {
                Console.WriteLine("Ingrese el numero " + (i + 1) + ": ");
                data[i] = Funciones.numValDouble(double.MinValue, double.MaxValue);
            }

            return data;
        }

        public double Sumar(double[] data)
        {
            double result = 0;
            foreach(double num in data)
            {
                result += num;
            }
            return result;
        }

        public double Restar(double[] data)
        {
            double result = data[0];
            for (int i = 1; i < data.Length; i++)
            {
                result -= data[i];
            }
            return result;
        }

        public double Multiplicar(double[] data)
        {
            double result = 1;
            foreach (double num in data)
            {
                result *= num;
            }
            return result;
        }

        public double Dividir(double[] data)
        {
            data[1] = data[1] == 0 ? 1 : data[1];
            double result = data[0] / data[1];
            return result;
        }
    }
}
