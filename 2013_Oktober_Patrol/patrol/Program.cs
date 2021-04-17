using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace patrol
{
    class Program
    {
        struct cars
        {
            public int hours;
            public int minutes;
            public int seconds;
            public string registrationnum;
        }
        static void kiir(long max2)
        {
            long ora = max2 / 3600;
            long perc = (max2 % 3600) / 60;
            long mp = (max2 % 3600) % 60;
            Console.WriteLine("{0}:{1}:{2}", ora, perc, mp);

        }
        static long masodperc(cars ido)
        {
            return ido.hours * 3600 + ido.minutes * 60 + ido.seconds;
            

        }
        static int hossz = File.ReadAllLines("vehicles.txt").Length;
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("vehicles.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            int index = 0;
            cars[] car = new cars[1000];
            while (true)
            {
                string line = sr.ReadLine();
                if (line == null)
	                {
		             break;
	                 }
                string[] uj = line.Split(' ');
                car[index].hours = int.Parse(uj[0]);
                car[index].minutes = int.Parse(uj[1]);
                car[index].seconds = int.Parse(uj[2]);
                car[index].registrationnum = uj[3];
                index++;
            }
            sr.Close();
            fs.Close();
            /*for (int i = 0; i < hossz; i++)
            {
                Console.WriteLine(  car[i].hours + " " +
                car[i].minutes + " "+
                car[i].seconds + " " +
                car[i].registrationnum);
            }
              */
            Console.WriteLine("EXERCISE 2:");
            int min = car[0].hours;
            int max = car[0].hours;
            for (int i = 0; i < hossz; i++)
            {
                if (min > car[i].hours)
                {
                    min = car[i].hours;
                }
            }
            for (int i = 0; i < hossz; i++)
            {
                if (max < car[i].hours)
                {
                    max = car[i].hours;
                }
            }

            Console.WriteLine(max + 1 - min);
           
            Console.WriteLine("EXERCISE 3: ");
            int aktualisora = 25;
            for (int i = 0; i < hossz; i++)
            {
                if (aktualisora != car[i].hours)
                {
                    Console.WriteLine(car[i].hours + " hours: " +car[i].registrationnum);
                    aktualisora = car[i].hours;
                }
            }








            Console.WriteLine( "EXERCISE 4:"); // else if-el is lehet!!!
            int motor = 0;
            int truck = 0;
            int bus = 0;
            for (int i = 0; i < hossz; i++)
            {
                
                    if (car[i].registrationnum.Contains("B"))
                    {
                        bus++;
                    }
                
            }
            for (int i = 0; i < hossz; i++)
            {
                
                    if (car[i].registrationnum.Contains("M"))
                    {
                        motor++;
                    }
                
            }
            for (int i = 0; i < hossz; i++)
            {
                
                    if (car[i].registrationnum.Contains("K"))
                    {
                        truck++;
                    }
                
            }
            Console.WriteLine("number of busses: {0}, number of trucks: {1}, number of motors: {2}", bus, truck, motor);
            Console.WriteLine("EXERCISE 5: ");
           long max2= 0;

            for (int i = 0; i < hossz-1; i++)
            {
               
                if (masodperc(car[i+1]) - masodperc(car[i]) > max2)
                {
                    max2 = masodperc(car[i+1]) - masodperc(car[i ]);
                    
                }
            }
            long ora = max2 / 3600;
            long perc = (max2 % 3600) / 60;
            long mp = (max2 % 3600) % 60;
            Console.WriteLine(max2 % 3600 );
            Console.WriteLine("EXERCISE 6:");
            kiir(max2);




            Console.WriteLine("PLEASE GIVE THE REMEMBERED NUMBERS OF THE REGISTARTION NUMBER AND REPLACE THE UNKKNOWN WITH *:");
            string search = Console.ReadLine();
            int searched = 0;
            for (int i = 0; i < hossz; i++)
            {
                if (car[i].registrationnum.Contains(search))
                {
                    searched = i;
                }
            }
            Console.WriteLine(car[searched].registrationnum);
            Console.WriteLine("EXERCISE 7: ");

            FileStream fs2 = new FileStream("checked.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs2);
            long ellenorzott = masodperc(car[0]);
            sw.WriteLine(car[0].registrationnum + " " + car[0].hours + " " + car[0].minutes + " " + car[0].seconds);
            for (int i = 0; i < hossz; i++)
            {
                if (masodperc(car[i])- ellenorzott >= 300 )
                {
                    ellenorzott = masodperc(car[i]);
                    sw.WriteLine(car[i].registrationnum + " " + car[i].hours + " " + car[i].minutes + " " + car[i].seconds);
                }
                
            }
            sw.Close();
            fs2.Close();



            Console.ReadKey();
        }
    }
}
