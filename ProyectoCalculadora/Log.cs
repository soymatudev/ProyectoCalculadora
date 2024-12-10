using System.Text; // Para codificar el mensaje en UTF8
using System.Security.Cryptography; // Para encriptar el mensaje con SHA256

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
            this.SHA256 = SHA256.Create(); // Crea el objeto SHA256 para encriptar los mensajes de log
            this.username = username; // Guarda el nombre de usuario
        }

        public string logPath()
        {
            // Crea la carpeta logs en la carpeta de usuario de la aplicacion
            string logDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProyectoCalculadora", "logs");
            Directory.CreateDirectory(logDirectory); // Crea la carpeta si no existe <= de ese si acuerdate
            string logFilePath = Path.Combine(logDirectory, "process.log"); // Crea el archivo process.log en la carpeta logs
            return logFilePath;
        }
        
        public void WriteLog(string message, string fun)
        {
            try
            {   
                string msg = message;
                // Encripta el mensaje con SHA256 y lo guarda en el archivo process.log
                byte[] hashmessage = this.SHA256.ComputeHash(Encoding.UTF8.GetBytes(message));
                string logfile = string.Format(logPath());
                message = PrintByteArray(hashmessage); // Convierte el mensaje en un string hexadecimal
                // Escribe el mensaje en el archivo process.log con el formato [fecha] - [usuario] - [funcion] >>> [mensaje]
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
            // Convierte un array de bytes en un string hexadecimal
            string result = "";
            for (int i = 0; i < array.Length; i++)
            {
                result = result + $"{array[i]:X2}";
                if ((i % 4) == 3) result += " ";
            }
            return result;
        }
    }
}
