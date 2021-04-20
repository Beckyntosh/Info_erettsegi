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
        struct politikus
        {
            public int valasztokerulet;
            public int szavazatok;
            public string nev;
            public string part;
        }
        static int hossz = File.ReadAllLines("szavazatok.txt").Length;
        static void Main(string[] args)
        {
            Console.WriteLine("FELADAT 1: BEOLVASÁS");
            FileStream FS = new FileStream("szavazatok.txt", FileMode.Open);
            StreamReader sr = new StreamReader(FS);
            politikus[] egy = new politikus[100];
            int index = 0;

            while (true)
            {

                string uj = sr.ReadLine();
                if (uj == null)
                {
                    break;
                }
                String[] tmp = uj.Split(' ');
                egy[index].valasztokerulet = int.Parse(tmp[0]);
                egy[index].szavazatok = int.Parse(tmp[1]);
                egy[index].nev = tmp[2] + " " + tmp[3];
                egy[index].part = tmp[4];


                //Console.WriteLine("{0} {1} {2} {3}", egy[index].valasztokerulet, egy[index].szavazatok, egy[index].nev, egy[index].part);
                index++;
            }
            sr.Close();
            FS.Close();
            Console.WriteLine("FELADAT 2: ");
            Console.WriteLine("A helyhatósági választáson {0} képviselőjelölt indult.", hossz);
            Console.WriteLine("FELADAT 3:");
            Console.WriteLine("ADJA meg a keresett képviselő nevét");
            string kepviselo = Console.ReadLine();
            bool vane = false;
            for (int i = 0; i < hossz; i++)
            {
                if (String.Compare(kepviselo, egy[i].nev) == 0)
                {
                    vane = true;
                    Console.WriteLine("A keresett képviselő {0} szavazatott kapott", egy[i].szavazatok);
                }
            }

            if (vane == false)
            {
                Console.WriteLine("Ilyen nevű képviselőjelölt nem szerepel a nyilvántartásban!");
            }


            Console.WriteLine("FELADAT 4: ");

            double szavazatosszeg = 0;
            for (int i = 0; i < hossz; i++)
            {
                szavazatosszeg = szavazatosszeg + egy[i].szavazatok;
            }
            Console.WriteLine("A választáson {0} állampolgár, a jogosultak {1}%-a vett részt.", szavazatosszeg, Math.Round(szavazatosszeg / 12345 * 100));

            Console.WriteLine("Feladat 5: ");
            double hep = 0;
            double gyep = 0;
            double zep = 0;
            double tisz = 0;
            double egyeb = 0;
            for (int i = 0; i < hossz; i++)
            {
                if (string.Compare(egy[i].part, "HEP") == 0)
                {
                    hep = hep + egy[i].szavazatok;
                }
                else if (string.Compare(egy[i].part, "GYEP") == 0)
                {
                    gyep = gyep + egy[i].szavazatok;
                }
                else if (string.Compare(egy[i].part, "ZEP") == 0)
                {
                    zep = zep + egy[i].szavazatok;
                }
                else if (string.Compare(egy[i].part, "TISZ") == 0)
                {
                    tisz = tisz + egy[i].szavazatok;
                }
                else
                {
                    egyeb = egyeb + egy[i].szavazatok;
                }
            }
            Console.WriteLine("Zöldségevők Pártja: {0}%", (zep / szavazatosszeg * 100).ToString("0.##"));
            Console.WriteLine("Húsevők Pártja: {0}%", Math.Round(hep / szavazatosszeg * 100));
            Console.WriteLine("Gyümölcsevők Pártja: {0}%", Math.Round(gyep / szavazatosszeg * 100));
            Console.WriteLine("Tejivók szövetsége: {0}%", Math.Round(tisz / szavazatosszeg * 100));
            Console.WriteLine("Függetlenek Pártja: {0}%", Math.Round(egyeb / szavazatosszeg * 100));

            Console.WriteLine("FELADAT 6: ");
            int max = 0;
            for (int i = 1; i < hossz; i++)
                if (max < egy[i].szavazatok)
                {
                    max = egy[i].szavazatok;
                }
            for (int i = 0; i < hossz; i++)
                if (egy[i].szavazatok == max)
                {
                    Console.Write(egy[i].nev + " ");
                    if (egy[i].part == "-")
                    {
                        Console.WriteLine("független");
                    }
                    else
                    {
                        Console.WriteLine(egy[i].part);
                    }
                }
            Console.WriteLine("FELADAT 7:");
            int[] nyertesekindexe = new int[8];
            for (int i = 1; i <= 8; i++)
            {
                int max2 = 0;
                int index2 = 0;

                for (int j = 0; j < hossz; j++)
                {
                    if (egy[j].valasztokerulet == i && max2 < egy[j].szavazatok)
                    {
                        max2 = egy[j].szavazatok;
                        index2 = j;
                    }
                }
                nyertesekindexe[i - 1] = index2;
            }
            FileStream fs2 = new FileStream("kepviselo.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs2);
            for (int i = 0; i < 8; i++)
            {
                sw.WriteLine("az {0} választó kerület nyertese {1}  és tamogatoja {2}", i + 1, egy[nyertesekindexe[i]].nev, egy[nyertesekindexe[i]].part);

            }
            sw.Close();
            fs2.Close();
            
            Console.ReadKey();
        }
    }
}

