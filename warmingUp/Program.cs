
using System.Collections;
using warmingUp.Task3;


namespace warmingUp 
{
    class Program 
    {
        public static void Main(string[] args) 
        {
            DigitalTimerLogic timerLogic = new DigitalTimerLogic();

            //timerLogic.start();


            StudentRegistration registration = new StudentRegistration("Anri", "Chubinidze", 212);
            

            Console.ReadLine();

            //task3 n1

            List<string> arrayList = new List<string> { "Anri", "Giorgi", "Saba", "jaba" };

            arrayList.Print();
            //task3 n2

            Person person = new Person
            {
                Name = "Nika",
                Age = 1,
                City = "Tbilisi"
            };

            Console.WriteLine(person.IsLocateedInTbilisi());

        }
    
    }
}