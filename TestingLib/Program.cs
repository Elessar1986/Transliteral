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
                Translit trans = new Translit();
                string testString = "Юрій Корюківка Ярошенко Знам'янка Згорани Розгон Щербухи Гоща Гаращенко ";
                Console.WriteLine("Оригинал строки:");
                Console.WriteLine(testString);
                Console.WriteLine("Базовое преобразование:");
                Console.WriteLine(trans.ukrToLat(testString));

                trans["г"] = "g";
                trans["Г"] = "G";
                Console.WriteLine("Измененное преобразование:");
                Console.WriteLine(trans.ukrToLat(testString));

                trans.ResetDictionary();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
