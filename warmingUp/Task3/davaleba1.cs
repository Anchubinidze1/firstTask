﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
