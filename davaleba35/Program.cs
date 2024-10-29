
using System.Linq;

namespace davaleba35 
{
    class Program 
    {
        public static void Main(string[] args) 
        {
            //davaleba 1

            int[] nums = { 4, 5, 6, 7, 8 };

            var squareMoreThan = nums.Select(num => new { number = num, sql = num * num }).Where(x => x.sql > 20);


            foreach (var square in squareMoreThan)
            {
                Console.WriteLine($"num: {square.number}, sqr: {square.sql}");
            }

            //davaleba2

            string randomText = "Here is some random text";

            var findout = randomText.ToCharArray().GroupBy(x => x);

            foreach (var find in findout)
            {
                Console.WriteLine($"Char : {find.Key} , {find.Count()} times");
            }

            //davaleba3

            List<int> numbers = new List<int> { 45, 30, 240, 66, 180, 590, 421 };

            var moreThen80 = numbers.Where(number => number > 80);

            foreach (var number in moreThen80)
            {
                Console.Write(number + " ");
            }

            //davaleba 4

            List<int> numbers1 = new List<int> { 45, 30, 240, 66, 180, 590, 421 };
            Console.WriteLine("Please enter the amount on number you want to be displayd on the screen");
            int answear = Convert.ToInt32(Console.ReadLine());

            var amountofNumbers = numbers1.Where((number, index) => index < answear);

            foreach (var number in amountofNumbers) { Console.WriteLine(number + " "); }


            //davaleba5

            char[] charset = { 'X', 'Y', 'Z' };
            int[] numset = { 1, 2, 3 };
            string[] colorset = { "Green", "Orange" };

            var display = from c in charset
                          from n in numset
                          from color in colorset
                          select new { Char = $"{c}", Number = $"{n}", Color = $"{color}" };

            foreach (var displayy in display)
            {
                Console.WriteLine($"character = {displayy.Char}, number = {displayy.Number}, colorset = {displayy.Color}");
            }

            //davaleba6

            IList<Product> prodcutList = new List<Product>()
            {
                new Product() {ItemId=1, ItemDes = "Tea"},
                new Product() {ItemId=2, ItemDes = "Bread"},
                new Product() {ItemId=3, ItemDes = "Milk"},
                new Product() {ItemId=4, ItemDes = "Meat"},
            };

            IList<Purchase> purchaseList = new List<Purchase>()
            {
                new Purchase() {InvoiceNu = 490, ItemId=2, PurchaseQuantity = 340 },
                new Purchase() {InvoiceNu = 700, ItemId=4, PurchaseQuantity = 100 },
                new Purchase() {InvoiceNu = 50, ItemId=3, PurchaseQuantity = 70 },
                new Purchase() {InvoiceNu = 200, ItemId=1, PurchaseQuantity = 700 }
            };

            var joiningConllectoins = prodcutList.Join(purchaseList,
                    product => product.ItemId,
                    purchase => purchase.ItemId,
                    (product , purchase) => new 
                    {
                       ItemID = product.ItemId,
                       ItemName = product.ItemDes,
                       SoldQuantity = purchase.PurchaseQuantity
                    }
                );

            Console.WriteLine("Item ID\t      Item Name\tSaled Quantity");

            foreach( var purchase in joiningConllectoins) 
            {
                Console.WriteLine($"{purchase.ItemID}\t\t{purchase.ItemName}\t\t{purchase.SoldQuantity}");
            }
        }
    }
}