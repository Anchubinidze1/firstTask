
using System.Collections;
using warmingUp.Task3;
using static System.Net.WebRequestMethods;


namespace warmingUp 
{

    class Program 
    {
        public delegate bool LinkEndsWith(string url, string endsWith);
        
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

            foreach ( var geLink in getLinks ) 
            {
                Console.WriteLine($"This link ends with '.ge' : {geLink}");
            }

            /// davaleba 4 dasrulda
            /// 

            //davaleba 5
            string chooseYourLinkEnding = ".Com";

            LinkEndsWith linkEnds = (link, domein) => link.DoesLinkEndWith(chooseYourLinkEnding);

            IEnumerable<string> getLinkss = linkEndsWith.Where(link => linkEnds(link, chooseYourLinkEnding));

            getLinkss.Print();
        }
    
    }
}