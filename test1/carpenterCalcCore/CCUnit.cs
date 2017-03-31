using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace carpenterCalcCore
{
    public class CCUnit
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

        public CCUnit changeTerms(int newTerm)
        {
            if (newTerm == denominator)
                return this;
            else
            {
                double factor = ((double)newTerm) / ((double)denominator);
                CCUnit newUnit = new CCUnit(wholeNum, (int)(((double)numerator) * factor), newTerm, error);
                return newUnit;
            }
        }

        //public static CCUnit calculate(char optr, CCUnit right, float metadata)
        //{
        //    switch(optr)
        //    {
        //        case '+':
        //            return this + right;

        //        case '-':
        //            return this - right;

        //        case '*':


        //    }
        //}

        public static CCUnit operator +(CCUnit left, CCUnit right)
        {
            left.changeToImproper();
            right.changeToImproper();
            CCUnit newLeft = left.changeTerms(16);
            CCUnit newRight = right.changeTerms(16);

            CCUnit result = new CCUnit(0, newLeft.numerator + newRight.numerator, 16, left.error + right.error);

            result.reduce();
            result.changeToProper();

            return result;
        }

        public static CCUnit operator -(CCUnit left, CCUnit right)
        {
            left.changeToImproper();
            right.changeToImproper();
            CCUnit newLeft = left.changeTerms(16);
            CCUnit newRight = right.changeTerms(16);

            CCUnit result = new CCUnit(0, left.numerator - right.numerator, 16, left.error + right.error);

            result.reduce();
            result.changeToProper();

            return result;
        }

        public static CCUnit operator /(CCUnit left, CCUnit right)
        {
            if (right.numerator != 0)
                return left;

            left.changeToImproper();
            CCUnit newLeft = left.changeTerms(16);

            CCUnit result = new CCUnit(0, left.numerator / right.wholeNum, 16, left.error);

            result.reduce();
            result.changeToProper();

            return result;
        }

        public static CCUnit operator *(CCUnit left, CCUnit right)
        {
            if (right.numerator == 0 && right.wholeNum == 0)
                return left;

            left.changeToImproper();
            right.changeToImproper();

            CCUnit result = new CCUnit(0, left.numerator * right.numerator, left.denominator * right.denominator, left.error + right.error);

            result = result.changeTerms(16);
            result.reduce();

            return result;
        }

        public void changeToImproper()
        {
            if (wholeNum == 0)
                return;

            numerator += wholeNum * denominator;
            wholeNum = 0;
        }

        public void changeToProper()
        {
            if (wholeNum > 0)
                return;

            wholeNum = numerator / denominator;
            numerator = numerator % denominator;
        }

        public void reduce()
        {
            if (numerator % denominator == 0)
            {
                wholeNum += numerator / denominator;
                numerator = 0;
                return;
            }

            while (numerator % 2 == 0)
            {
                numerator /= 2;
                denominator /= 2;
            }
        }

    }
}
