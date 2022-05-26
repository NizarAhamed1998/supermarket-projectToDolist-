using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Product pdt = new Product();
            pdt.filetodict();
            Console.WriteLine(pdt.display());
            Console.WriteLine("if you want change any product detail plz type changedetail");
            if ("changedetail"==Console.ReadLine())
            {
                do
                {
                     Console.WriteLine("Enter the productid");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("type product rate or mfgdate or expdate or netweight");
                string name = Console.ReadLine().ToLower();
                Console.WriteLine("Enter the new value");
                string val = Console.ReadLine();
                pdt.changevalue(id, name, val);
                Console.WriteLine("if you want continue type yes or no");
                } while ("yes"==Console.ReadLine());
            }
            pdt.dicttofile();
            Console.WriteLine(pdt.display());
        }
    }
}
