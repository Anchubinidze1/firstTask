using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warmingUp.Task3
{
    internal class Person
    {
        public string Name {  get; set; }
        public int Age { get; set; }
        public string City { get; set; }


        public override string ToString()
        {
            return "Name of this person is : " + Name + "\n" + "Age of this person is : " + Age + "\n" + "This person live in " + City + "\n";
        }
    }
}
