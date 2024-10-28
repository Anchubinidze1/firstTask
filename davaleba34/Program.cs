
namespace davaleba34 
{
    class Program
    {
        public static void Main(string[] args) 
        {
            // davaleba 1

            int[] n1 = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var numbers = from number in n1
                     where number%2 == 0
                     select number;

            foreach (var number in numbers) 
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
            // davaleba 2

            int[] n2 = { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 };

            var numbers2 = from number in n2
                           where number > 0
                           where number < 12
                           select number;

            foreach(var number in numbers2)
                Console.Write(number + " ");

            //davaleba 3

            int[] nums = new int[] { 5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2 };

            var groupedNumbers = nums.GroupBy(number => number);

            foreach(var number in groupedNumbers) 
            {
                Console.WriteLine($"Number: {number.Key} , Reteated {number.Count()}");
            }

            // davaleba 4

            Console.WriteLine("Please Enter the first Character of the city");
            string startingChar = Console.ReadLine();
            Console.WriteLine("Please Enter the last Characted of the city");
            string endsWithChar = Console.ReadLine();



            string[] cities = { "ROME", "LONDON", "NAIROBI", "CALIFORNIA", "ZURICH", "NEW DELHI", "AMSTERDAM", "ABU DHABI", "PARIS" };

            var checkCity = cities.Where(city =>  city.StartsWith(startingChar.ToUpper()) && city.EndsWith(endsWithChar.ToUpper()));

            foreach(var city in checkCity) 
            {
                Console.WriteLine(city);
            }

            //davaleba 5

            string example = "this IS a STRING";

            var findingBigWords = example.Split(' ').Where(word => word == word.ToUpper());

            foreach(var word in findingBigWords) 
            {
                Console.WriteLine(word);
            }
        }
    }    
}