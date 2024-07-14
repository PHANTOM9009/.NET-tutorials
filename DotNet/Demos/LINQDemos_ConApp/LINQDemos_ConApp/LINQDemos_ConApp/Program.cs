using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemos_ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Linq3_Projection_Simple();
           // LinqRestriction();
            //Linq5_Projection_Anonymous();
            //Linq7_Partitioning_Take_Simple();
            Linq9_Partitioning_TakeWhile_Simple();
            //Linq8_Partitioning_Skip_Simple();

            //Linq10_Ordering_OrderBy();
            //Linq11_Grouping_GroupBy();
            //Linq12_Element_FirstOrDefault();
            //Linq13_Aggregate_Count();
            //
            //Linq_Union();
            //Linq_Except();
            //Linq_Intersect();
           // Linq_Select_SelectMany();
            //
            Console.ReadLine();
        }

        static void Linq3_Projection_Simple()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var nums =
                from num in numbers
                select num;

            Console.WriteLine("Numbers:-----");
            foreach (var i in nums)
            {
                Console.WriteLine(i);
            }
        }
        static void LinqRestriction()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var lowNums =
                from num in numbers
                where num < 5
                select num;

            Console.WriteLine("Numbers < 5:-----");
            Console.WriteLine("\n");
            foreach (var x in lowNums)
            {
                Console.WriteLine(x);
            }
        }

        /*
        static void Linq2_Restriction()
        {
            
            List<Product> products = GetProductList();

            var soldOutProducts =
                from prod in products
                where prod.UnitsInStock == 0
                select prod;

            Console.WriteLine("Sold out products:");
            foreach (var product in soldOutProducts)
            {
                Console.WriteLine("{0} is sold out!", product.ProductName);
            }
             
        }
    */

        static void Linq5_Projection_Anonymous()
        {
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var upperLowerWords =
                from word in words
                select new { Upper = word.ToUpper(), Lower = word.ToLower() };


            foreach (var wordPair in upperLowerWords)
            {
                //rtbLinqQueryEditor.AppendText("Uppercase: {0}, Lowercase: {1}",
                //wordPair.Upper, wordPair.Lower);
                Console.WriteLine("Uppercase: " + wordPair.Upper
                    + " \t Lowercase:" + wordPair.Lower);
            }
        }

        /*
        static void Linq4_Projection_Transformation()
        {
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //string[] strings =
            //{ "zero", "one", "two", "three", "four", "five",
            //    "six", "seven", "eight", "nine" };

            //var textNums =
            //    from num in numbers
            //    select strings[num];

            //rtbLinqQueryEditor.AppendText("Number strings:");
            //rtbLinqQueryEditor.AppendText("\n");
            //foreach (var str in textNums)
            //{
            //    rtbLinqQueryEditor.AppendText(str + " ");
            //}
        }
        
        static void Linq6_Projection_Compund()
        {
            //int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            //int[] numbersB = { 1, 3, 5, 7, 8 };

            //var pairs =
            //    from a in numbersA
            //    from b in numbersB
            //    where a < b
            //    select new { a, b };

            //rtbLinqQueryEditor.AppendText("Pairs where a < b:");
            //foreach (var pair in pairs)
            //{
            //    rtbLinqQueryEditor.AppendText(pair.a + " is less than" + pair.b + "\n ");
            //}
        }
        */

        static void Linq7_Partitioning_Take_Simple()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var first3Numbers = numbers.Take(3);

            Console.WriteLine("First 3 numbers:-----");
            foreach (var n in first3Numbers)
            {
                Console.WriteLine(n );
            }
        }
        static void Linq9_Partitioning_TakeWhile_Simple()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);

            Console.WriteLine("First numbers less than 6:-----");
            foreach (var num in firstNumbersLessThan6)
            {
                Console.WriteLine(num);
            }
        }

        static void Linq8_Partitioning_Skip_Simple()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var allButFirst4Numbers = numbers.Skip(4);

            Console.WriteLine("All but first 4 numbers:-----");

            foreach (var n in allButFirst4Numbers)
            {
                Console.WriteLine(n);
            }
        }
        static void Linq10_Ordering_OrderBy()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords =
                from word in words
                orderby word ascending
                select word;

            Console.WriteLine("The sorted list of words:");
            foreach (var w in sortedWords)
            {
                Console.WriteLine(w);
            }
        }

        static void Linq11_Grouping_GroupBy()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numberGroups =
                from num in numbers
                group num by num % 5 into numGroup
                select new { Remainder = numGroup.Key, Numbers = numGroup };

            foreach (var grp in numberGroups)
            {
                Console.WriteLine(
                    "Numbers with a remainder of " + grp.Remainder
                    + " when divided by 5:-----");

                foreach (var n in grp.Numbers)
                {
                    Console.WriteLine(n);
                }
            }
        }

        static void Linq12_Element_First()
        {
            /*
            List<Product> products = GetProductList();

            Product product12 = (
                from prod in products
                where prod.ProductID == 12
                select prod)
                .First();

            ObjectDumper.Write(product12);
             * */
        }

        static void Linq12_Element_FirstOrDefault()
        {
            /*
            int[] numbers = {12,23,45,56};
            int firstNumOrDefault = numbers.First();
            */
            int[] numbers = {};
            int firstNumOrDefault = numbers.FirstOrDefault();
            

            Console.WriteLine(firstNumOrDefault);
        }

        static void Linq13_Aggregate_Count()
        {
            int[] nums = { 2, 2, 3, 5, 5 };

            int uniqueNums = nums.Distinct().Count();

            Console.WriteLine("Count of Unique Nums: "
                + uniqueNums);
        }

        static void Linq_Union()
        {
            string[] a = new string[] { "a", "b", "c", "d" };
            string[] b = new string[] { "d", "e", "f", "g" };
            Console.WriteLine(
                "Elements of First array(a):{ a,b,c,d}");
            Console.WriteLine(
                "Elements of Second array(b):{ d,e,f,g}");
            string[] UnResult = a.Union(b).ToArray();
            Console.WriteLine("\n");
            Console.WriteLine("Union Result:----------");
            foreach (string s in UnResult)
            {
                Console.WriteLine(s.ToString());
            }
        }
        static void Linq_Except()
        {
            //
            int[] ints1 = { 5, 3, 9, 7, 5, 9, 3, 7 };
            int[] ints2 = { 8, 3, 6, 4, 4, 9, 1, 0 };
            Console.WriteLine(
                "Elements of FirstArray(ints1):{ 5, 3, 9, 7, 5, 9, 3, 7 }");
            Console.WriteLine(
                "Elements of SecondArray(ints2):{ 8, 3, 6, 4, 4, 9, 1, 0 }");
            int[] Except = ints1.Except(ints2).ToArray();
            //Console.WriteLine("\n");
            Console.WriteLine("Except Result:----------");
            //Console.WriteLine("\n");
            foreach (int num in Except)
            {
                Console.WriteLine(num.ToString());
                Console.WriteLine("\n");
            }
        }

        static void Linq_Intersect()
        {
            int[] FirstArray = { 1, 2, 3, 8, 9, 10 };
            int[] SecondArray = { 2, 3, 4, 5, 6, 7 };
            Console.WriteLine("Elements of FirstArray:{ 1, 2, 3,8,9,10 }");
            Console.WriteLine("Elements of SecondArray:{ 2, 3, 4,5,6,7 }");
            Console.WriteLine("");
            Console.WriteLine("Intersect Result:----------");
            Console.WriteLine("");
            int[] Results = FirstArray.Intersect(SecondArray).ToArray();
            foreach (int Result in Results)
            {
                Console.WriteLine(Result.ToString());
            }
        }
        
        /*
        static void Linq_Union_Except_Intersect()
        {
            string[] a = { "a", "b", "c", "d" };
            string[] b = { "d", "e", "f", "g" };

            var UnResult = a.Union(b);
            Console.WriteLine("Union Result");
            Console.WriteLine("\n");
            foreach (string s in UnResult)
            {
                Console.WriteLine(s.ToString());
            }

            var ExResult = a.Except(b);
            Console.WriteLine("Except Result");
            foreach (string s in ExResult)
            {
                Console.WriteLine(s.ToString());
                Console.WriteLine("");
            }

            var InResult = a.Intersect(b);
            Console.WriteLine("Intersect Result");
            Console.WriteLine("");
            foreach (string s in InResult)
            {
                Console.WriteLine(s.ToString());
            }


        }
        */

        static void Linq_Select_SelectMany()
        {
            List<Bouquet> bouquets = new List<Bouquet>()
            {
                new Bouquet
                { Flowers = new List<string> { "sunflower", "daisy", "daffodil", "larkspur" }},
                new Bouquet
                { Flowers = new List<string> { "tulip", "rose", "orchid" }},
                new Bouquet
                { Flowers = new List<string> { "gladiolis", "lily", "snapdragon", "aster", "protea" }},
                new Bouquet
                { Flowers = new List<string> { "larkspur", "lilac", "iris", "dahlia" }}
            };

            // *********** Select ***********            
            IEnumerable<List<string>> query1 = bouquets.Select(bq => bq.Flowers);

            // ********* SelectMany *********
            IEnumerable<string> query2 = bouquets.SelectMany(bq => bq.Flowers);

            Console.WriteLine("Results by using Select():------");

            // Note the extra foreach loop here.
            foreach (IEnumerable<String> collection in query1)
            {
                foreach (string item in collection)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine("Results by using SelectMany():------");
            foreach (string item in query2)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    class Bouquet
    {
        public List<string> Flowers { get; set; }
    }
}
