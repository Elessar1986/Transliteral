using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TransliteralLib
{
    public class Translit
    {

        private static Dictionary<string, string> TransDict = new Dictionary<string, string>()
        {
            {"А", "A" },{"а", "a" },
            {"Б", "B" },{"б", "b" },
            {"В", "V" },{"в", "v" },
            {"Г", "H" },{"г", "h" },
            {"Ґ", "G" },{"ґ", "g" },
            {"Д", "D" },{"д", "d" },
            {"Е", "E" },{"е", "e" },
            {"Є", "Ye" },{"є", "ie" },
            {"Ж", "Zh" },{"ж", "zh" },
            {"З", "Z" },{"з", "z" },
            {"И", "Y" },{"и", "y" },
            {"І", "I" },{"і", "i" },
            {"Ї", "Yi" },{"ї", "i" },
            {"Й", "Y" },{"й", "i" },
            {"К", "K" },{"к", "k" },
            {"Л", "L" },{"л", "l" },
            {"М", "M" },{"м", "m" },
            {"Н", "N" },{"н", "n" },
            {"О", "O" },{"о", "o" },
            {"П", "P" },{"п", "p" },
            {"Р", "R" },{"р", "r" },
            {"С", "S" },{"с", "s" },
            {"Т", "T" },{"т", "t" },
            {"У", "U" },{"у", "u" },
            {"Ф", "F" },{"ф", "f" },
            {"Х", "Kh" },{"х", "kh" },
            {"Ц", "Ts" },{"ц", "ts" },
            {"Ч", "Ch" },{"ч", "ch" },
            {"Ш", "Sh" },{"ш", "sh" },
            {"Щ", "Shch" },{"щ", "shch" },
            {"Ю", "Yu" },{"ю", "iu" },
            {"Я", "Ya" },{"я", "ia" },
            {"ь", "" },{"'", "" }
        };

        public static string ukrToLat(string textToTrans, Dictionary<string,string> translitDictionary = null)
        {
            if (Regex.IsMatch(textToTrans, @"[a-zA-Z]")) throw new Exception("String contains latin symbols!");
            if (translitDictionary == null) translitDictionary = TransDict;
            StringBuilder result = new StringBuilder();
            List<string> words = textToTrans.Split(' ').ToList();

            foreach (var word in words)
            {
                StringBuilder res = new StringBuilder();
                for (int i = 0; i < word.Length; i++)
                {
                    if (Char.IsUpper(word[i]))
                    {
                        if (i == 0)
                        {
                            res.Append(translitDictionary[word[i].ToString()]);
                        }
                        else
                        {
                            res.Append(translitDictionary[word[i].ToString().ToLower()].ToUpper());
                        }
                    }
                    else
                    {
                        if (i == 0)
                        {
                            res.Append(translitDictionary[word[i].ToString().ToUpper()].ToLower());
                        }
                        else
                        {
                            res.Append(translitDictionary[word[i].ToString()]);
                        }
                    }
                }
                //Filters
                if (word.ToUpper().Contains("ЗГ"))
                {
                    res.Replace("zh", "zgh");
                    res.Replace("Zh", "Zgh");
                }

                result.Append(res + " ");

            }

            return result.ToString();
        }

    }
}
