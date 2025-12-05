using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace Convert_Program1
{
    class Program
    {
        static string[] number_man = { "", "Один", "Два", "Три", "Четыре", "Пять", "Шесть", "Семь", "Восемь", "Девять" };
        static string[] numbers_elewen = { "Десять", "Одиннадцать", "Двенадцать", "Тринадцать", "Четырнадцать", "Пятнадцать", "Шестнадцать", "Семнадцать", "Восемнадцать", "Девятнадцать" };
        static string[] numbers_tens = { "", "Десять", "Двадцать", "Тридцать", "Сорок", "Пятьдесят", "Шестьдесят", "Семьдесят", "Восемьдесят", "Девяносто" };
        static string[] numbers_hundreds = { "", "Сто", "Двести", "Триста", "Четыреста", "Пятьсот", "Шестьсот", "Семьсот", "Восемьсот", "Девятьсот" };
        static string[,] unit = { { "тысяча", "тысячи", "тысяч" }, { "миллион", "миллиона", "миллионов" } };
        static string[] number_wumen = { "", "Одна", "Две", "Три", "Четыре", "Пять", "Шесть", "Семь", "Восемь", "Девять" };
        static string[] rub_text = { "рублей", "рубль", "рубля" };
        static void Main(string[] args)
        {
            string global_hundreds = "";
            string global_thousands = "";
            string global_million = "";
            string global_rub = "";
            while (true)
            {
                Console.Write("Число 1 :");
                int input = Convert.ToInt32(Console.ReadLine());
                string output = "";
                for (int i = 0; input > 0; i++)
                {
                    int triple = input % 1000;
                    input /= 1000;
                    string part = separation(triple, i);
                }
                string separation(int numb, int quanti)
                {
                    int hundred = numb / 100;
                    int tens = (numb % 100) / 10;
                    int ones = numb % 10;
                    if (quanti == 0)
                    {
                        string numb_ones = number_man[ones];
                        string numb_tens = tens == 1 ?
                            numbers_elewen[ones] : $"{numbers_tens[tens]} {numb_ones}";
                        string numb_hundreds = $"{numbers_hundreds[hundred]} {numb_tens.ToLower()}";
                        int tensAndOne = numb % 100;

                        string rub =
                          (tensAndOne >= 10 && tensAndOne < 19) ?
                         $"{rub_text[0]}" : ones == 1 ?
                          $"{rub_text[1]}" : (ones >= 2 && ones <= 4) ?
                          $"{rub_text[2]}" : $"{rub_text[0]}";
                        global_rub = rub;
                        global_hundreds = numb_hundreds;
                    }
                    else if (quanti == 1)
                    {
                        string name_ones_thousands = ones == 1 ?
                            unit[0, 0] : (ones >= 2 && ones <= 4) ?
                            unit[0, 1] : unit[0, 2];
                        string name_tens_thousands = tens == 1 ?
                           unit[0, 2] : name_ones_thousands;
                        string numb_ones = number_wumen[ones];
                        string numb_tens = tens == 1 ?
                            numbers_elewen[ones] : $"{numbers_tens[tens]} {numb_ones}";
                        string numb_thousands = $"{numbers_hundreds[hundred]} {numb_tens} {name_tens_thousands.ToLower()}";
                        global_thousands = numb_thousands;
                    }
                    else
                    {
                        string name_ones_thousands = ones == 1 ?
                            unit[1, 0] : (ones >= 2 && ones <= 4) ?
                            unit[1, 1] : unit[1, 2];
                        string name_tens_thousands = tens == 1 ?
                           unit[1, 2] : name_ones_thousands;

                        string numb_ones = number_man[ones];
                        string numb_tens = tens == 1 ?
                            numbers_elewen[ones] : $"{numbers_tens[tens]} {numb_ones}";
                        string numb_million = $"{numbers_hundreds[hundred]} {numb_tens.ToLower()} {name_tens_thousands.ToLower()}";
                        global_million = numb_million;
                    }
                    return "";
                }
                output = $"{global_million} {global_thousands} {global_hundreds} {global_rub.ToLower()}";
                Console.WriteLine(output.Trim());
            }

        }
    }
}
