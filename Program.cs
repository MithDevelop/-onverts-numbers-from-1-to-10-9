using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace Conver
{
    class Program
    {
        static string[] integers = { "", "Один", "Два", "Три", "Четыре", "Пять", "Шесть", "Семь", "Восемь", "Девять" };
        static string[] decimal_numbers_elew = { "Десять", "Одиннадцать", "Двенадцать", "Тринадцать", "Четырнадцать", "Пятнадцать", "Шестнадцать", "Семнадцать", "Восемнадцать", "Девятнадцать" };
        static string[] decimal_numbers = { "", "Десять", "Двадцать", "Тридцать", "Сорок", "Пятьдесят", "Шестьдесят", "Семьдесят", "Восемьдесят", "Девяносто" };
        static string[] hundreds = { "", "Сто", "Двести", "Триста", "Четыреста", "Пятьсот", "Шестьсот", "Семьсот", "Восемьсот", "Девятьсот" };
        static string[] thousUnit = { "тысяча", "тысячи", "тысяч" };
        static string[] thousNum = { "", "Одна", "Две", "Три", "Четыре", "Пять", "Шесть", "Семь", "Восемь", "Девять" };
        static void Main(string[] args)
        {
            string print = "";
            string separation_hundreds(int numb)
            {
                int hundred = numb / 100;
                int tensAndOne = numb % 100;
                int tens = tensAndOne / 10;
                int ones = numb % 10;
                string rub_text =ones == 1? "рубль": (ones >= 2 && ones <=4)? "рубля" :  "рублей";
                //----------------------------------------------------------------------------------//
                string hund = $"{hundreds[hundred]} {decimal_numbers[tens].ToLower()} {integers[ones].ToLower()}";
                string hund_elew = $"{hundreds[hundred]} {decimal_numbers_elew[ones].ToLower()}";
                string elewen = (tensAndOne >= 10 && tensAndOne <= 19) ? hund_elew : hund;
                //----------------------------------------------------------------------------------//
                string output = $"{elewen} {rub_text}";
                return output;
            }
            string separation_hundreds_no_ruble(int numb)
            {
                int hundred = numb / 100;
                int tensAndOne = numb % 100;
                int tens = tensAndOne / 10;
                int ones = numb % 10;
                //----------------------------------------------------------------------------------//
                string hund = $"{hundreds[hundred]} {decimal_numbers[tens].ToLower()} {integers[ones].ToLower()}";
                string hund_elew = $"{hundreds[hundred]} {decimal_numbers_elew[ones].ToLower()}";
                string elewen = (tensAndOne >= 10 && tensAndOne <= 19) ? hund_elew : hund;
                //----------------------------------------------------------------------------------//
                return elewen;
            }
            string separation_bilions(int numb)
            {
                int billions = (numb / 1000000000) % 1000;
                int millions = (numb / 1000000) % 1000;
                int thousands = (numb / 1000) % 1000;
                int hundredsPart = numb % 1000;

                // от 1тыс до 999 тыс
                int last_two_thousands = thousands % 100;
                int last_thousands = thousands % 10;
                string declination_thousands = (last_two_thousands >= 11 && last_two_thousands <= 19) ? thousUnit[2] :
                              (last_thousands == 1 ? thousUnit[0] :
                              (last_thousands >= 2 && last_thousands <= 4 ? thousUnit[1] : thousUnit[2]));

                //----------------------------------------------------------------------------------//
                string thousand_text = (thousands >= 100) ?
                    $"{hundreds[thousands / 100]} {decimal_numbers[last_two_thousands / 10]} {thousNum[last_two_thousands % 10]} " :
                        (last_two_thousands >= 11 && last_two_thousands <= 19) ?
                            $"{decimal_numbers_elew[last_two_thousands % 10]}" :
                        (last_two_thousands >= 20) ?
                            $"{decimal_numbers[last_two_thousands / 10]} {thousNum[last_two_thousands % 10]}".Trim() :
                        (last_thousands >= 1 && last_thousands <= 9) ?
                            $"{thousNum[last_thousands]}" : "";


                // от 1 миллиона до 999 миллионов
                string mill_text = (millions % 100 >= 11 && millions % 100 <= 19) ? "миллионов" :
                    (millions % 10 == 1) ? "миллион" :
                    (millions % 10 >= 2 && millions % 10 <= 4) ? "миллиона" :
                     "миллионов";
                //----------------------------------------------------------------------------------//
                string mill_numb = millions == 0 ? "" : $"{separation_hundreds_no_ruble(millions)} {mill_text}";
                string hundreds_text = separation_hundreds(hundredsPart).ToLower();


                // от 1 миллиарда до 999 миллиардов
                string billions_text = (billions % 100 >= 11 && billions % 100 <= 19) ? 
                    "миллиардов" : (billions % 10 == 1) ?
                    "миллиард" : (billions % 10 >= 2 && billions % 10 <= 4) ?
                    "миллиарда" : "миллиардов";
                //----------------------------------------------------------------------------------//
                string billions_numb = billions == 0 ? "" : $"{separation_hundreds(billions)} {billions_text}"; ;
                return $"{billions_numb.Trim()} {mill_numb.Trim()} {thousand_text.Trim()} {declination_thousands.Trim()} {hundreds_text.Trim()}";
            }
             while (true)
            {
                Console.Write("Введите число: ");
                int input = Convert.ToInt32(Console.ReadLine());
                int length = input.ToString().Length;
                switch (length)
                {
                    case <= 3:
                        print = separation_hundreds(input);
                        break;
                    case <= 12:
                        print = separation_bilions(input);
                        break;
                }
                Console.WriteLine(print.Trim());
            }
        }
    }
}
