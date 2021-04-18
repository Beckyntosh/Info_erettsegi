using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace zeneiadok
{
    class Program
    {
        struct adok
        {
           public int sorszam;
           public long perc;
            public long masodperc;
            public string cim;
            public long elteltido;
        }
        static bool keresettSzam (string betuk,string cim)
        {
            int j = 0;
            for (int i = 0; i < betuk.Length; i++)
            {
                    while ( cim.Length > j && betuk[i] != cim[j])
                {
                    j++;
                }
                    if (cim.Length == j)
                    {
                        return false;
                    }
            }
            return true;


        }
        static long idoBeszur (adok[] ado, int adosorszam, int hossz)
        {
            long elteltido = 0;
            for (int i = 0; i < hossz; i++)
			{
			 if (ado[i].sorszam == adosorszam)
	            {
                    elteltido += ado[i].perc * 60 + ado[i].masodperc;
	            }
			}
            return elteltido;

        }
        static bool joe(adok ido) 
        { 
            return ((ido.elteltido/3600) < (ido.masodperc + ido.perc*60) );
           /*if ((ido.elteltido/3600) < (ido.masodperc + ido.perc*60) )
            {
                return true;
            }
            else
	{
        return false;*/
	
        }
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("musor.txt",FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            adok[] zeneado = new adok[1000];
            
            int hossz = int.Parse(sr.ReadLine());
            for (int i = 0; i < hossz; i++)
            {
                zeneado[i].elteltido = 0;
            }
            for (int i = 0; i < hossz; i++)
            {

                string line = sr.ReadLine();
                if (line == null)
                {
                    break;
                }

                string[] uj = line.Split(' ');
                int sorszam = int.Parse(uj[0]);
                long perc = long.Parse(uj[1]);
                long masodperc = long.Parse(uj[2]);
                string ideglenes = string.Join(" ", uj, 3, uj.Length - 3);
                string cim = ideglenes;
                    zeneado[i].sorszam = sorszam;
                    zeneado[i].perc = perc;
                    zeneado[i].masodperc = masodperc;
                    zeneado[i].cim = cim;
                    long elteltido;
               
                
                elteltido = idoBeszur(zeneado, zeneado[i].sorszam, i);     
                
                zeneado[i].elteltido = elteltido;
                }
           
            
            fs.Close();
            sr.Close();
           /* for (int i = 0; i < hossz; i++)
            {
                Console.WriteLine(zeneado[i].sorszam + " " +
                    zeneado[i].perc + " "+
                    zeneado[i].masodperc + " " +
                    zeneado[i].cim);
            }
             */
            Console.WriteLine("FELADAt 2:");
            int egyesado = 0;
            int kettesado = 0;
            int harmasado = 0;
            for (int i = 0; i < hossz; i++)
            {
                

                if (zeneado[i].sorszam == 1)
                {
                    egyesado++;
                }
                if (zeneado[i].sorszam == 2)
                {
                    kettesado++;
                }
                if (zeneado[i].sorszam == 3)
                {
                    harmasado++;
                }
            }

                Console.WriteLine(egyesado + " " + kettesado + " " + harmasado);

                Console.WriteLine("FELADAT 3: ");
            int elso = 0;
            int masodik = 0;
                for (int i = 0; i < hossz; i++)
                {
                    if (zeneado[i].sorszam == 1)
                    {
                        if (zeneado[i].cim.Contains("Eric Clapton"))
                        {
                            elso = i;
                            break;
                        }
                    }
                }
                for (int i = 0; i < hossz; i++)
                {
                    if (zeneado[i].sorszam == 1)
                    {
                        if (zeneado[i].cim.Contains("Eric Clapton"))
                        {
                            masodik = i;
                        }
                    }
                }
                long idotelt = (zeneado[masodik].elteltido + zeneado[masodik].masodperc + (zeneado[masodik].perc * 60)) - zeneado[elso].elteltido;
               long hours = idotelt / 3600;
               long minutes = (idotelt % 3600) / 60;
               long seconds = (idotelt % 3600) % 60;
               Console.WriteLine(idotelt);
               Console.WriteLine("{0}:{1}:{2}", hours, minutes, seconds);
               //Console.WriteLine(zeneado[masodik].elteltido + " " + zeneado[elso].elteltido);

                Console.WriteLine("FELADAT 4: ");
                int omegaindex = 0;
                for (int i = 0; i < hossz; i++)
                {
                    if (zeneado[i].cim == "Omega:Legenda")
                    {
                        Console.WriteLine(zeneado[i].sorszam);
                        omegaindex = i;
                    }
                }
                int x = 0;
                int szam1 = 0;
                int szam2 = 0;
                while (zeneado[omegaindex].elteltido > zeneado[x].elteltido)
                {
                    if (zeneado[x].sorszam == 2)
                    {
                        szam1 = x;
                    }
                    
                    x++;
                }
                x = 0;
                while (zeneado[omegaindex].elteltido > zeneado[x].elteltido)
                {
                    if (zeneado[x].sorszam == 1)
                    {
                        szam2 = x;
                    }
                    x++;
                }
                Console.WriteLine(zeneado[szam1].cim + " " + zeneado[szam2].cim);

                Console.WriteLine("FELADAT 5: ");
                FileStream fs2 = new FileStream("keres.txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs2);
                Console.WriteLine("a keresett szám: ");
                string szam = Console.ReadLine();
                sw.WriteLine(szam);
                for (int i = 0; i < hossz; i++)
                {
                    if (keresettSzam(szam,zeneado[i].cim))
                    {
                        sw.WriteLine(zeneado[i].cim);
                    }
                    
                }
                sw.Close();
                fs2.Close();
                Console.WriteLine("FELADAT 6: ");
                //long hirek= 0;
                //long bevezeto = 0;
                long musorido = 0;
                for (int i = 0; i < hossz; i++)
                {
                    if (zeneado[i].sorszam == 1)
                    {            
                        zeneado[i].perc++;
                    }
                    if (zeneado[i].sorszam == 1 && joe(zeneado[i]))
                    {
                        musorido += zeneado[i].masodperc + (zeneado[i].perc * 60);
                    }
                    if (zeneado[i].sorszam == 1 && !joe(zeneado[i]))
                    {
                        musorido +=((musorido/3600)+1)*3600 -musorido;
                        musorido += 180;
                    }
                   
                }

                //Console.WriteLine(musorido);
                long musorora =musorido / 3600;
                long musorperc = (musorido % 3600)/60;
                long musormp = (musorido % 3600) % 60;
                Console.WriteLine("{0}:{1}:{2}", musorora, musorperc, musormp);
            Console.ReadKey();
        }
    }
}
