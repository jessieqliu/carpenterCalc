﻿using carpenterCalcCore;
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
            /*  if (args.Length > 0)
                  Console.WriteLine(args[0]);

              string jsonText = File.ReadAllText(args[0]);

              CCUnit unit1 = JsonConvert.DeserializeObject<CCUnit>(jsonText);
              Console.WriteLine("{0} {1} {2} {3}", unit1.wholeNum, unit1.numerator, unit1.denominator, unit1.error);

              jsonText = File.ReadAllText(args[1]);

              CCUnit unit2 = JsonConvert.DeserializeObject<CCUnit>(jsonText);
              Console.WriteLine("{0} {1} {2} {3}", unit2.wholeNum, unit2.numerator, unit2.denominator, unit2.error);


              unit1.wholeNum = 10;
              string newJson = JsonConvert.SerializeObject(unit1, Formatting.Indented, new JsonConverter[] { new StringEnumConverter()});

              Console.WriteLine(newJson);*/

            string jText = File.ReadAllText(args[0]);
            Request r1 = JsonConvert.DeserializeObject<Request>(jText);
            Console.WriteLine(r1.calcOperator);
            Console.WriteLine("{0} {1} {2} {3}", r1.CCUnits[0].wholeNum, r1.CCUnits[0].numerator, r1.CCUnits[0].denominator, r1.CCUnits[0].error);
            Console.WriteLine("{0} {1} {2} {3}", r1.CCUnits[1].wholeNum, r1.CCUnits[1].numerator, r1.CCUnits[1].denominator, r1.CCUnits[1].error);
            Console.WriteLine(r1.metadata);


        }

        static CCUnit calculate(CCUnit opd1, CCUnit opd2, char optr)
        {

            return opd1;
        }

        static CCUnit decToFrac(float dec)
        {
            int integral = (int)decimal.Truncate((decimal)dec);
            int fraction = (int)(((decimal)dec - decimal.Truncate((decimal)dec)) * 1000);

            float newError = (float)decimal.Truncate((decimal)(fraction / 62.5));

            CCUnit result = new CCUnit(integral, (int)(fraction / 62.5), 16, newError);
            result.reduce();

            return result;
        }
    }
}
