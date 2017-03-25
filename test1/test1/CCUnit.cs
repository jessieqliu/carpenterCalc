using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace test1
{
    class CCUnit
    {
        public CCUnit(int wholeNum, int numerator, int denominator, float error)
        {
            this.wholeNum = wholeNum;
            this.numerator = numerator;
            this.denominator = denominator;
            this.error = error;
        }

        [JsonProperty("wholeNum")]
        public int wholeNum { get; set; }

        [JsonProperty("numerator")]
        public int numerator { get; set; }

        [JsonProperty("denominator")]
        public int denominator { get; set; }

        [JsonProperty("error")]
        public float error { get; set; }
        
    }
}
