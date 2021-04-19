using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication5
{
    class Program
    {
        struct quiz
        {
            public string question;
            public int evszam;
            public int pont;
            public string type;
        }
        static int hossz = File.ReadAllLines("numberquest.txt").Length;
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("numberquest.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            quiz[] verseny = new quiz[hossz];
            int index = 0;
            while (true)
            {
                string line = sr.ReadLine();
                if (line == null)
                {
                    break;
                }
                //string[] uj = line.Split(' ');
                verseny[index].question = line;
                sr.ReadLine();
                string[] uj = line.Split(' ');
                verseny[index].evszam = int.Parse(uj[1]);
                verseny[index].pont = int.Parse(uj[2]);
                verseny[index].type = uj[3];
                index++;   
            }
            Console.WriteLine("EXERCISE 2: ");
            Console.WriteLine(hossz);
            Console.WriteLine("EXERCISE 3: ");
            int matekossz = 0;
            for (int i = 0; i < hossz; i++)
			{
			 if (verseny[i].type.CompareTo("mathematics") == 0)
	            {
		                matekossz++;
	            }
			}
            int egy =0;
            int ketto = 0;
            int harom = 0;
            for (int i = 0; i < hossz; i++)
			{
			 if (verseny[i].type.CompareTo("mathematics") == 0)
	            {
		            for (int k = 0; k < hossz; k++)
			{
			 if (verseny[k].pont == 1)
	            {
		             egy++;
	            }
               else if (verseny[k].pont == 2)
	            {
		 ketto++;
	              }
             else if (verseny[k].pont == 3)
	                {
		                    harom++;
	                }
			}
	            }
			}
            Console.WriteLine("The data file contains {0} mathematical questions, {1} questions are worth 1 point(s), {2} questions are worth 2 point(s), {3} questions are worth 3 point(s).", matekossz, egy, ketto, harom);

            Console.WriteLine("EXCERSIE 4: ");











            Console.ReadKey();
        }
    }
}
