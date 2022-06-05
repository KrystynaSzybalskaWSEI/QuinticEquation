using System;
using System.Collections.Generic;
using System.Linq;

namespace QuinticEquation
{
    class Program
    {
        static void Main(string[] args)
        {
            //wprowadzanie danych
            //input testowy - 1,0,-2,0,1,0 powinien dać wyniki -1,0,1
            double a = 0, b, c, d, e, f;

            Console.WriteLine("Algorytm rozwiązuje równanie piątego stopnia (dla liczb rzeczywistych): ax^5 + bx ^ 4 + cx ^ 3 + dx ^2 + ex +f = 0,");
            Console.WriteLine("dla podanego zakresu, kroku oraz dokładności.");

            while (a == 0)
            {
                Console.WriteLine("Wpisz a różne od 0");
                a = Double.Parse(Console.ReadLine());
            }

            Console.WriteLine("Wpisz b");
            b = Double.Parse(Console.ReadLine());
            Console.WriteLine("Wpisz c");
            c = Double.Parse(Console.ReadLine());
            Console.WriteLine("Wpisz d");
            d = Double.Parse(Console.ReadLine());
            Console.WriteLine("Wpisz e");
            e = Double.Parse(Console.ReadLine());
            Console.WriteLine("Wpisz f");
            f = Double.Parse(Console.ReadLine());


            double from, to, step, epsilon;
            Console.WriteLine("Wpisz zakres przeszukiwania (np. od -100 do 100, przedział zamknięty).\nOd:");
            from = Double.Parse(Console.ReadLine());
            Console.WriteLine("Do:");
            to = Double.Parse(Console.ReadLine());
            Console.WriteLine("Wpisz krok z jakim zakres ma być przeszukiwany (np. 0,001):");
            step = Double.Parse(Console.ReadLine());
            Console.WriteLine("Wpisz z jaką dokładnością szukasz wyniku (epsilon, np. 0,000001):");
            epsilon = Double.Parse(Console.ReadLine());

            List<double> results = new List<double>();
            
            for (double i = from; i <= to; i += step)
            {
                //przejdź przez zadany zakres
                if (CountQuinticEquationForGivenX(i, a, b, c, d, e, f) == 0)
                {
                    results.Add(i);
                }
                //porównaj każde dwie wartości, jeśli ich wynik jest ujemny, stosuj metodę połowienia zakresu aż znajdziesz zero
                if (i!=to && (CountQuinticEquationForGivenX(i, a, b, c, d, e, f) * CountQuinticEquationForGivenX(i+step, a, b, c, d, e, f)) < 0)
                {
                    double start = i, end = 1 + step, middle=0;
               
                    while (!((CountQuinticEquationForGivenX(start, a, b, c, d, e, f) - CountQuinticEquationForGivenX(end + step, a, b, c, d, e, f))<epsilon))
                    {
                        middle = (start + end) / 2;
                        if (middle * start < 0) end = middle;
                        else start = middle;
                    }
                    results.Add(CountQuinticEquationForGivenX(middle, a, b, c, d, e, f));
                }
            }

            //wypisz wynik
            Console.WriteLine($"Przy kroku {step}, w zakresie od {from} do {to} algorytm znalazł następujące pierwiastki rzeczywiste dla podanego równiania:\n");
            foreach (var item in results)
            {
                Console.WriteLine(Math.Round(item, 6));
            }
        }

        public static double CountQuinticEquationForGivenX(double x, double a, double b, double c, double d, double e, double f)
        {
            double result = a * x * x * x * x * x + b * x * x * x * x + c * x * x * x + d * x * x + e * x + f;
            return result;
        }
    }
}
