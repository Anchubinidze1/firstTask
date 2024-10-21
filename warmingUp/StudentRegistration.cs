using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warmingUp
{

    

    internal class StudentRegistration
    {
        public string _lastName {  get; set; }
        public string _firstName {  get; set; }
        public int id { get; set; }

        public event EventHandler studentRegistered;

        public bool IsStudentRegistered(string lastName, string firstName , int id) 
        {
            if(lastName != null && firstName !=null && id != null) 
            {
                return true;
            }

            return false;
        }

        public void RegisterStudent() 
        {

            OnStudentRegistered();
        }

        private void OnStudentRegistered() 
        {
            studentRegistered?.Invoke(this, EventArgs.Empty);
        }

        
    }
}
