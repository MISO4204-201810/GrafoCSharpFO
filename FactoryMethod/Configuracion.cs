using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class FileManagement
    {

        public FileManagement()
        {

        }
        public void SaveFile(string nombreArchivo, string datos)
        {
            string fileName = Path.Combine(Environment.CurrentDirectory, nombreArchivo);
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.CreateNew);
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.Write(datos);
                }
            }
            finally
            {
                if (fs != null)
                    fs.Dispose();
            }
        }
        

    }
    public class  Configuracion
    {
        public string TipoGrafo { get; set; }
        public string TipoPeso { get; set; }
        public string TipoBusqueda { get; set; }

        public Configuracion()
        {
            TipoGrafo = string.Empty;
            TipoPeso = string.Empty;
            TipoBusqueda = string.Empty;
        }
        public void ArmarConfiguracion(int opcion)
        {
            switch (opcion)
            {
                case 1:
                     TipoGrafo = "Directed";
                     TipoPeso = "Unweighted";
                     TipoBusqueda = "";
                    break;
                case 2:
                     TipoGrafo = "Directed";
                     TipoPeso = "Weighted";
                     TipoBusqueda = "";
                    break;
                case 3:
                     TipoGrafo = "Undirected";
                     TipoPeso = "Unweighted";
                     TipoBusqueda = "";
                    break;
                case 4:

                     TipoGrafo = "Undirected";
                     TipoPeso = "Weighted";
                     TipoBusqueda = "";
                    break;
                case 5:
                     TipoGrafo = "Directed";
                     TipoPeso = "Unweighted";
                     TipoBusqueda = "DFS";
                    break;
                case 6:
                     TipoGrafo = "Directed";
                     TipoPeso = "Weighted";
                     TipoBusqueda = "DFS";
                    break;
                case 7:
                     TipoGrafo = "Undirected";
                     TipoPeso = "Unweighted";
                     TipoBusqueda = "DFS";
                    break;
                case 8:
                     TipoGrafo = "Undirected";
                     TipoPeso = "Weighted";
                     TipoBusqueda = "DFS";
                    break;
                case 9:
                     TipoGrafo = "Directed";
                     TipoPeso = "Unweighted";
                     TipoBusqueda = "BFS";
                    break;
                case 10:
                     TipoGrafo = "Directed";
                     TipoPeso = "Weighted";
                     TipoBusqueda = "BFS";
                    break;
                case 11:
                     TipoGrafo = "Undirected";
                     TipoPeso = "Unweighted";
                     TipoBusqueda = "BFS";
                    break;
                case 12:
                     TipoGrafo = "Undirected";
                     TipoPeso = "Weighted";
                     TipoBusqueda = "BFS";
                    break;
                default:
                    Console.WriteLine("Opcion no valida para generar configuracion");
                    break;
            }
        }

        public int DisplayMenu()
        {

            Console.WriteLine("**************************************************************");
            Console.WriteLine("Escoja el Tipo de Configuracion a Ejecutar - Creador de Grafos");
            Console.WriteLine();
            Console.WriteLine("1. Directed - Unweighted");
            Console.WriteLine("2. Directed - Weighted");
            Console.WriteLine("3. Undirected - Unweighted");
            Console.WriteLine("4. Undirected - Weighted");
            Console.WriteLine("5. Directed - Unweighted - DFS");
            Console.WriteLine("6. Directed - Weighted - DFS");
            Console.WriteLine("7. Undirected - Unweighted - DFS");
            Console.WriteLine("8. Undirected - Weighted - DFS");
            Console.WriteLine("9. Directed - Unweighted - BFS");
            Console.WriteLine("10. Directed - Weighted - BFS");
            Console.WriteLine("11. Undirected - Unweighted - BFS");
            Console.WriteLine("12. Undirected - Weighted - BFS");

            Console.WriteLine("99. Salir");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }
    }
}