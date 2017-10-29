using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransliteralLib;

namespace TestingLib
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(Translit.ukrToLat("Юрій Корюківка Ярошенко Знам'янка Згорани Розгон Щербухи Гоща Гаращенко"));

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
