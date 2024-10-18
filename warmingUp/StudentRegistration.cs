using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warmingUp
{
    internal class StudentRegistration
    {
        private string _lastName;
        private string _firstName;
        private int id;

        private event EventHandler studentRegistered;

        public StudentRegistration(string lastName, string firstName , int id) 
        {
            _lastName = lastName;
            _firstName = firstName;
            this.id = id;

            RegisterStudent();
        }

        public void RegisterStudent() 
        {

            studentRegistered += SubscriberMethod;
            OnStudentRegistered();
        }

        private void OnStudentRegistered() 
        {
            studentRegistered?.Invoke(this, EventArgs.Empty);
        }

        private void SubscriberMethod(object sender , EventArgs e) 
        {
            Console.WriteLine($"You have been Registered Well Done \nTime of the registration: {DateTime.Now:HH.mm.ss}");
        }
    }
}
