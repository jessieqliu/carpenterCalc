using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0)
                Console.WriteLine(args[0]);

            string jsonText = File.ReadAllText(args[0]);

            CCUnit unit1 = JsonConvert.DeserializeObject<CCUnit>(jsonText);
            Console.WriteLine("{0} {1} {2} {3}", unit1.wholeNum, unit1.numerator, unit1.denominator, unit1.error);

            jsonText = File.ReadAllText(args[1]);

            CCUnit unit2 = JsonConvert.DeserializeObject<CCUnit>(jsonText);
            Console.WriteLine("{0} {1} {2} {3}", unit2.wholeNum, unit2.numerator, unit2.denominator, unit2.error);

            /*
            unit1.wholeNum = 10;
            string newJson = JsonConvert.SerializeObject(unit1, Formatting.Indented, new JsonConverter[] { new StringEnumConverter()});

            Console.WriteLine(newJson);*/
        }

        static CCUnit calculate(CCUnit opd1, CCUnit opd2, char optr)
        {
            int newDenom, newNumer, newWholeNum;

            newDenom = opd1.denominator == opd2.denominator ? opd1.denominator : opd1.denominator * opd2.denominator;


            return opd1;
        }

        static int getGCD(int num1, int num2)
        {
            int op1, op2;
            op1 = num1 < num2 ? num1 : num2;
            op2 = num1 > num2 ? num1 : num2;

            return 0;
        }
    }
}
