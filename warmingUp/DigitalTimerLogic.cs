using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace warmingUp
{
    internal class DigitalTimerLogic
    {

        private static Timer timer;

        public static event EventHandler SecondElapsed;

        public void start() 
        {
            
            timer = new Timer(OnTimedEvent , null , 0 , 1000);

            SecondElapsed += SubscriberMethod;
        }

        private void OnTimedEvent(object state) 
        {
           
            SecondElapsed?.Invoke(null, EventArgs.Empty);
        }

        private void SubscriberMethod(object sender, EventArgs e) 
        {
            Console.WriteLine($"Current Time : {DateTime.Now:HH:mm:ss}");
        }
        
    }
}
