﻿/*
 * Lab1
 * Отладка. Обработка массивов.
 * 
 * Часть1. Используя методы отладки по шагам найти ошибки в программе.
 * https://docs.microsoft.com/ru-ru/visualstudio/debugger/debugger-feature-tour?view=vs-2017
 * 
 * Часть2. Реализовать закоментированные методы из класса Lab1Array
 * Динамические структуры данных не использовать!
 */
using System;

namespace Lab1
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] a;
            Lab1Array.Read(out a);
            Lab1Array.Print(a);
            // TODO: Найдите ошибку в программе:
            Lab1Array.ReverseBetweenTwoMins(a);
            Lab1Array.Print(a);

            Console.ReadKey();
        }
    }
}
