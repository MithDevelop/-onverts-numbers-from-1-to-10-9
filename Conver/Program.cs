using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Security.Policy;
using System.Text;

namespace Conver
{
    class Program
    {
        static void Main(string[] args)
        {
           string[] num = { "", "Один", "Два", "Три", "Четыре", "Пять", "Шесть", "Семь", "Восемь", "Девять", "Десять", };
           string[] teen = { "Ошиб", "Одиннадцать", "Двенадцать", "Тринадцать", "Четырнадцать", "Пятнадцать", "Шестнадцать", "Семнадцать", "Восемнадцать", "Девятнадцать" };
           string[] teNum = { "","Десять", "Двадцать", "Тридцать", "Сорок", "Пятьдесят", "Шестьдесят", "Семьдесят", "Восемьдесят", "Девяносто" };
           string[] hundNum = { "", "Сто", "Двести", "Триста", "Четыреста", "Пятьсот", "Шестьсот", "Семьсот", "Восемьсот", "Девятьсот", "Одна тысяча" };
           string[] thousUnit = { "тысяча", "тысячи", "тысяч" };
           string[] thousNum = { "Ошиб", "Одна", "Две", "Три", "Четыре", "Пять", "Шесть", "Семь", "Восемь", "Девять" };
           string print = "";
           while (true)
           {
                Console.Write("Введите число: ");
                int input = Convert.ToInt32(Console.ReadLine());
                string output(int numb)
                {
                    if (numb < 100) return TenNub(numb);
                    if (numb < 1000) return Hund(numb);
                    if (numb < 10000) return Thous(numb);
                    if (numb < 100000) return ten_thou(numb);
                    return "";
                }

                string Onenub(int numb)
                {
                    if (numb >= 0 && numb <= 10)
                        return num[numb];
                    return ele_twent(numb);
                }
                string ele_twent(int numb)
                {
                    if (numb >=11 && numb <=19)
                        return teen[numb - 10];
                    return TenNub(numb);
                }
                string TenNub(int numb)
                {
                    int OneNumb_Ten = numb / 10;
                    int TwoNumb_Ten = numb % 10;

                    if (OneNumb_Ten == 0)
                        return teNum[OneNumb_Ten];

                    if (numb >= 20 && numb <= 99)
                        if (numb % 10 == 0)
                            return teNum[OneNumb_Ten];
                        else
                            return $"{teNum[OneNumb_Ten]} {num[TwoNumb_Ten]}";
                    return Hund(numb);
                }
                string Hund(int numb)
                {
                    int OneNumb_Hun = numb / 100;
                    int TwoNumb_Hun = numb % 100;

                    if (numb < 100 && numb >= 0)
                        return Onenub(numb);

                    if (TwoNumb_Hun == 0)
                        return hundNum[OneNumb_Hun];

                    if (numb >= 100 && numb <= 1000)
                        if (TwoNumb_Hun >= 10 && TwoNumb_Hun <= 19)
                            return $"{hundNum[OneNumb_Hun]} {ele_twent(TwoNumb_Hun)}";
                        else if (TwoNumb_Hun >= 0 && TwoNumb_Hun <= 10)
                            return $"{hundNum[OneNumb_Hun]} {Onenub(TwoNumb_Hun)}";
                        else 
                            return $"{hundNum[OneNumb_Hun]} {TenNub(TwoNumb_Hun)}";
                    return Thous(numb);
                }
                string Thous(int numb)
                {

                    int OneNumb_Thous = numb / 1000;
                    int TwoNumb_Thous = numb % 1000;

                    string One = $"{thousNum[OneNumb_Thous]} {thousUnit[0]}";
                    string Two_Fo = $"{thousNum[OneNumb_Thous]} {thousUnit[1]}";
                    string Fiv_Nin = $"{thousNum[OneNumb_Thous]} {thousUnit[2]}";
                    
                    if (OneNumb_Thous  == 0)
                    {
                        return Hund(numb);
                    }

                    if (numb >= 1000 && numb <= 9999)
                        if (OneNumb_Thous == 1)
                            if (TwoNumb_Thous > 0)
                                return $"{One} {Hund(TwoNumb_Thous)}";
                            else
                                return $"{One}";
                    if (OneNumb_Thous >= 2 && OneNumb_Thous <= 4)
                        if (TwoNumb_Thous > 0)
                            return $"{Two_Fo} {Hund(TwoNumb_Thous)}";
                        else
                            return $"{Two_Fo}";

                    if (OneNumb_Thous >= 5 && OneNumb_Thous <= 9)
                        if (TwoNumb_Thous > 0)
                            return $"{Fiv_Nin} {Hund(TwoNumb_Thous)}";
                        else
                            return $"{Fiv_Nin}";
                    return ten_thou(numb);
                }
                string ten_thou(int numb)
                {
                    int OneNumb_ten_Thous = numb / 10000;
                    int TwoNumb_ten_Thous = numb % 10000;

                    string ten = $"{teNum[OneNumb_ten_Thous]} {thousUnit[2]}";
                    string Tent_Hund = $"{teNum[OneNumb_ten_Thous]} {Thous(TwoNumb_ten_Thous)}"; 

                    if (OneNumb_ten_Thous == 0)
                    {
                        return Thous(numb);
                    }

                    if (numb >= 10000 && numb <= 99999)
                        if (TwoNumb_ten_Thous == 0)
                            return $"{ten}";
                        else
                            return $"{Tent_Hund}";
                    return "";
                }

                Console.WriteLine(output(input));
           }
        }
    }
}
