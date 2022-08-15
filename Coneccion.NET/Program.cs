using Coneccion.NET.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalsss
{
    public class ProbandoObjetos
    {

        static void Main(string[] args)
        {
            ProductoHandler productoHandler = new ProductoHandler();

            List<string> descrpciones = productoHandler.GetTodaslasDescripcionesAdapter();

            foreach (var item in descrpciones)
            {
                Console.WriteLine(item);
            }
        }
    }

}
