using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.IO.Pipes;

namespace ProyectoCalculadora
{
    public class program
    {
        public Funciones Funciones = new Funciones();
        private Log Log = null;
        public string username = "s";
        public static void Main(string[] args)
        {
            program program = new program();
            program.init();
        }

        public void init()
        {
            this.initUser();
            Calculadora calc = new Calculadora(menu(), this.username);
            if (repeat() == 1) program.Main(null);
            else this.Log.WriteLog("", string.Format("El usuario: {0} ha finalizado sesion", this.username));  Environment.Exit(0);
        }
        public void initUser()
        {
            Console.WriteLine("Ingrese su nombre de usuario: ");
            this.username = Console.ReadLine().Trim();
            this.Log = new Log(this.username);
            this.Log.WriteLog("", string.Format("El usuario: {0} ha iniciado sesion", this.username));
        }

        public int menu()
        {
            int option = 0;
            Console.WriteLine("1. Sumar");
            Console.WriteLine("2. Restar");
            Console.WriteLine("3. Multiplicar");
            Console.WriteLine("4. Dividir");
            Console.WriteLine("5. Salir");
            Console.WriteLine("Ingrese una opción: ");
            option = Convert.ToInt32(this.Funciones.numVal(1, 5));
            if (option == 5) this.Log.WriteLog("", string.Format("El usuario: {0} ha finalizado sesion", this.username));  Environment.Exit(0);
            return option;
        }

        public int repeat()
        {
            Console.WriteLine("Desea realizar otra operacion?");
            Console.WriteLine("1. Si");
            Console.WriteLine("2. No");
            int option = Convert.ToInt32(this.Funciones.numVal(1, 2));
            return option;
        }
    }

    public class Funciones
    {
        public int numVal(int min, int max)
        {
            int numero;
            while (true)
            {
                string entrada = Console.ReadLine();
                if (int.TryParse(entrada, out numero) && numero >= min && numero <= max)
                {
                    return numero;
                }
                Console.WriteLine("Entrada inválida. Por favor, intenta nuevamente.");
            }
        }

        public int numValDouble(double min, double max)
        {
            int numero;
            while (true)
            {
                string entrada = Console.ReadLine();
                if (int.TryParse(entrada, out numero) && numero >= min && numero <= max)
                {
                    return numero;
                }
                Console.WriteLine("Entrada inválida. Por favor, intenta nuevamente.");
            }
        }
    }
}