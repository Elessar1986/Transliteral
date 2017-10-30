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

        private Dictionary<string, string> currentDict;

        public Translit()
        {
            currentDict = CreateDafaultDict();

            RegisterFilterHendler(ZghFilter);         
        }


        public Translit(Dictionary<string, string> UserDict)        //конструктор для установки своего словаря
        {
            currentDict = UserDict;

            RegisterFilterHendler(ZghFilter);
        }

        private Dictionary<string, string> CreateDafaultDict()
        {
            return new Dictionary<string, string>()  // стандартный словарь с правилами перевода
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

        }

        public void ResetDictionary()       //Сброс настроек
        {
            currentDict = CreateDafaultDict();
        }

        public string this[string index]        //переопределяем для изменения кнкретных значений текущего словаря
        {
            get
            {
                if (currentDict.ContainsKey(index) == false)                                            
                    throw new IndexOutOfRangeException($"Dictionary doesn't contain key = {index}");
                return currentDict[index];
            }
            set
            {
                if (currentDict.ContainsKey(index) == true)                                 
                    currentDict[index] = value;                                             
                else
                    currentDict.Add(index, value);                                          
            }
        }

        public delegate void FilterHendler(ref string text, string text1);   //делегат для добавления фильтров
        FilterHendler filterHendler;

        public void RegisterFilterHendler(FilterHendler filter)
        {
            filterHendler += filter;
        }

        public void UnregisterFilterHendler(FilterHendler filter)
        {
            filterHendler -= filter;
        }

        private void ZghFilter(ref string text, string text1)       // филтр для сочетаний "зг"
        {
            if (text1.ToUpper().Contains("ЗГ"))
            {
                text = text.Replace("zh", "zgh");
                text = text.Replace("Zh", "Zgh");
            }
        }

        public string ukrToLat(string textToTrans, bool filters = true)         //метод для перевода
        {
            if (Regex.IsMatch(textToTrans, @"[a-zA-Z]")) throw new Exception("String contains latin symbols!");
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
                            res.Append(currentDict[word[i].ToString()]);
                        }
                        else
                        {
                            res.Append(currentDict[word[i].ToString().ToLower()].ToUpper());
                        }
                    }
                    else
                    {
                        if (i == 0)
                        {
                            res.Append(currentDict[word[i].ToString().ToUpper()].ToLower());
                        }
                        else
                        {
                            res.Append(currentDict[word[i].ToString()]);
                        }
                    }
                }

                string resTemp = res.ToString();
                
                if (filters)
                {
                    filterHendler(ref resTemp, word);       //Фильтры
                }

                result.Append(resTemp + " ");

            }

            return result.ToString();
        }

    }
}
