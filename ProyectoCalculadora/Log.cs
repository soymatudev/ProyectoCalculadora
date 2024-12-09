using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace ProyectoCalculadora
{
    internal class Log
    {
        private string username;
        private string fun;
        private SHA256 SHA256;
        public Log(string username)
        {
            // ruta similar: cd C:\Users\numbe\AppData\Roaming\ProyectoCalculadora\logs\
            // equivalente a tail -f: Get-Content -Path "process.log" -Wait 
            this.SHA256 = SHA256.Create();
            this.username = username;
        }

        public string logPath()
        {
            string logDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProyectoCalculadora", "logs");
            Directory.CreateDirectory(logDirectory); // Crea la carpeta si no existe <= de ese si acuerdate
            string logFilePath = Path.Combine(logDirectory, "process.log");
            //Console.WriteLine(logFilePath);
            return logFilePath;
        }
        
        public void WriteLog(string message, string fun)
        {
            try
            {//File.AppendAllText(logFilePath, "Este es un registro de prueba.\n");
                string msg = message;
                byte[] hashmessage = this.SHA256.ComputeHash(Encoding.UTF8.GetBytes(message));
                string logfile = string.Format(logPath());
                message = PrintByteArray(hashmessage);
                using (StreamWriter LogWrite = new StreamWriter(logfile, true))
                {
                    LogWrite.WriteLine(string.Format("[{0}] - {1} - {2} >>> {3}", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"), this.username, fun, (msg != "" ? message : "")));
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private static string PrintByteArray(byte[] array)
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
            {
                //Console.Write($"{array[i]:X2}");
                result = result + $"{array[i]:X2}";
                if ((i % 4) == 3) result += " ";
            }
            return result;
        }
    }
}
