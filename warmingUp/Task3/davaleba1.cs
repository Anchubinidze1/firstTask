using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace warmingUp.Task3
{
    static class davaleba1
    {
        public static void Print<T>(this IEnumerable<T> tasks) 
        {
            foreach(var task in tasks) 
            {
                Console.Write(task + " ");
            }
            Console.WriteLine();
        }

        //meore davalebistvis

        public static bool IsLocateedInTbilisi(this Person person) 
        {
            string toLower = person.City.ToLower();
            if(toLower != "tbilisi" ) 
            {
                return false;
            }

            return true;
        }


        //mesame davalebis

        public static Person YourgestOfTwo(this Person person1 , Person person2) 
        {
            if (person1.Age > person2.Age)
            {
                return person1;
            }
            else if (person1.Age < person2.Age)
            {
                return person2;
            }

            else return null;
        }

        //davaleba 4

        public static bool DoesLinkEndWithGe(this string str) 
        {
            if (!str.EndsWith(".ge")) 
            {
                return false;
            }

            return true;
        }

        //davaleba 5

        public static bool DoesLinkEndWith(this string str , string endsWirth) 
        {
            return str.EndsWith(endsWirth , StringComparison.OrdinalIgnoreCase);
        }

       


    }
}
