
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


            List<string> arrayList = new List<string> { "Anri", "Giorgi", "Saba", "jaba" };

            arrayList.Print();
            
            
        }
    
    }
}