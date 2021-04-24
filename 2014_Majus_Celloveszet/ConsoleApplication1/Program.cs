using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static int shotscore(string loves)
        {
            int current = 20;
            int score = 0;
            for (int i = 0; i < loves.Length; i++)
            {
                if (current > 0 && loves[i] == '-')
                {
                    current = current - 1;
                }
                else
                {
                    score = score + current;
                }
            }
            return score;

        }
        static bool sorszam(string loves)
        {
            bool vane = false;
            for (int i = 0; i < loves.Length-1; i++)
            {
                if (loves[i] == '+' && loves[i+1] == '+')
                {
                    vane = true;
                }
            }
            return vane;
        }
        static int pontszam (string loves)
        {
            int osszpont = 0;
            for (int i = 0; i < loves.Length; i++)
            {
                if (loves[i] == '+')
                {
                    osszpont++;
                }
            }
            return osszpont;
        }
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("contest.txt",FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            int szam = int.Parse(sr.ReadLine());
            Console.WriteLine(szam);
            string[] loves = new string[szam];
            for (int i = 0; i < szam; i++)
            {
                string line = sr.ReadLine();
                loves[i] = line;
               // Console.WriteLine(loves[i]);
            }
            sr.Close();
            fs.Close();
            Console.WriteLine("FELADAT 2");
           for (int i = 0; i < szam; i++)
            {
                if (sorszam(loves[i]))
                {
                    Console.Write(i + " ");
                }
            }
           Console.WriteLine();
           Console.WriteLine("FELADAT 3:");
           int max = 0;
           int maxindex = 0;
           int aktualispont = 0;
           for (int i = 0; i < szam; i++)
           {
               aktualispont = pontszam(loves[i]);
               if (max < aktualispont)
               {
                   max = aktualispont;
                   maxindex = i;
               }
           }

           Console.WriteLine(maxindex);
           //Console.WriteLine(pontszam("---+++---"));
           Console.WriteLine("FELADAT 4:");
           Console.WriteLine("FELADAT 5:");
           Console.WriteLine("Adja meg a keresett lövész számát!");
           int entry = Convert.ToInt32(Console.ReadLine());
           Console.Write("a: ");
           for (int i = 0; i < loves[entry].Length; i++)
           {
               if (loves[entry][i] == '+')
               {
                   Console.Write( i + " ");
               }
           }
           Console.WriteLine();
           int lovesszam = 0;
           for (int i = 0; i < loves[entry].Length; i++)
           {
               if (loves[entry][i] == '+')
               {
                   lovesszam++;
               }
           }
           Console.WriteLine("b: " + lovesszam);
          // Console.WriteLine(pontszam(loves[entry]));
            int aktualisloves = 0;
            int maxloves= 0;
           for (int i = 0; i < loves[entry].Length; i++)
           {
               if (loves[entry][i] == '+')
               {
                   aktualisloves++;
               }
               else
               {
                   if (maxloves < aktualisloves)
                   {
                       maxloves = aktualisloves;
                      
                   }
                   aktualisloves = 0;
               }
           }
           Console.WriteLine(  "C: " + maxloves);
           Console.WriteLine("d: " + shotscore(loves[entry]));


           Console.WriteLine("FELADAT 6: ");
           FileStream fs2 = new FileStream("order.txt",FileMode.Create);
           StreamWriter sw = new StreamWriter(fs2);
           int helyezes = 1;
            for (int i = 0; i < loves.Length; i++)
            {
                for (int j = 0; j < loves.Length-1; j++)
                {
                        if (shotscore(loves[j])<shotscore(loves[j+1]))
                    {
                           string tmp = loves[j+1];
                           loves[j +1]= loves[j];
                           loves[j]= tmp;
                    }
                }
            }

            for (int i = 0; i < loves.Length; i++)
			{
			  sw.WriteLine(helyezes+ " " +loves[i] + " " +shotscore(loves[i]));
                helyezes++;
			}

            sw.Close();
            fs2.Close();

          


            Console.ReadKey();
        }
    }
}
