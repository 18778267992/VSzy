using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numList = { 10, 20, 30, 40, 11, 42, 61, 51, 87 };
            var query1 = from x in numList
                         where x % 2 == 0
                         select x;
            var query2 = numList.Where(x => x % 2 == 0).OrderBy(x => x);
            foreach (var item in query2)
            {
                Console.Write(item.ToString() + "");
            }
            Console.ReadKey();
        }
    }
}
