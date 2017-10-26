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
            Console.WriteLine(Translit.ukrToLat("Тернопіль Йосипівка Борщагівка"));

            //Console.WriteLine(Translit.ukrToLat(Console.ReadLine()));

            Console.ReadKey();
        }
    }
}
