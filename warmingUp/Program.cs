
using System.Collections;
using warmingUp.Task3;
using static System.Net.WebRequestMethods;


namespace warmingUp 
{
    

    class Program 
    {
        public delegate bool LinkEndsWith(string url, string endsWith);

       
        private static void SubscriberMethod(object sender, EventArgs e)
        {
            Console.WriteLine($"You have been Registered Well Done \nTime of the registration: {DateTime.Now:HH.mm.ss}");
        }


        public static void Main(string[] args) 
        {
            /*
            DigitalTimerLogic timerLogic = new DigitalTimerLogic();

            

            //timerLogic.start();


            

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

            Person person2 = new Person
            {
                Name = "Anri",
                Age = 2,
                City = "Not in Tbilisi"
            };

            Console.WriteLine(person.YourgestOfTwo(person2));

            // davaleba 4

            string[] linkEndsWith = { "https://github.com"
                    ,"https://www.tutorialsteacher.com"
                    ,"https://on.ge"
                    ,"https://police.ge"
                    ,"https://www.ug.edu.ge"
                    ,"https://stackoverflow.com"
            };

            Func<string, bool> checkGeDomeain = link => link.DoesLinkEndWithGe();

            var getLinks = linkEndsWith.Where(checkGeDomeain).ToList();  
            */

            /*
            foreach ( var geLink in getLinks ) 
            {
                Console.WriteLine($"This link ends with '.ge' : {geLink}");
            }
            */

            /*
            getLinks.Print();
            /// davaleba 4 dasrulda
            /// 

            //davaleba 5
            string chooseYourLinkEnding = ".Com";

            LinkEndsWith linkEnds = (link, domein) => link.DoesLinkEndWith(chooseYourLinkEnding);

            IEnumerable<string> getLinkss = linkEndsWith.Where(link => linkEnds(link, chooseYourLinkEnding));

            getLinkss.Print();


            

            
            */

            //davaleba 2 uketesi

            List<StudentRegistration> students = new List<StudentRegistration>() 
            { 
                new StudentRegistration { _firstName = "Anri" , _lastName = "Chubinidze" , id = 1},
                new StudentRegistration { _firstName = "Nika" , _lastName = "Chubin" , id = 2},
                new StudentRegistration { _firstName = "Luka" , _lastName = "Chu" , id = 3},
                new StudentRegistration { _firstName = "Giorgi" , _lastName = "Ch" , id = 4}
            };

            foreach (var student in students) 
            {
                Console.WriteLine(student.IsStudentRegistered(student._lastName,student._firstName,student.id));
                student.studentRegistered += SubscriberMethod;
                student.RegisterStudent();
            }
        }
    
    }
}