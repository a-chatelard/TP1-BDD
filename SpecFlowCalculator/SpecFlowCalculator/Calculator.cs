using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SpecFlowCalculator
{
    public class Calculator
    {
        public string Calculus { get; set; }
        public decimal FirstNumber { get; set; }
        public decimal SecondNumber { get; set; }

        public decimal Add()
        {
            return FirstNumber + SecondNumber;
        }

        public decimal Substract()
        {
            return FirstNumber - SecondNumber;
        }

        public decimal Multiply()
        {
            return FirstNumber * SecondNumber;
        }

        public decimal Divide()
        {
            return FirstNumber / SecondNumber;
        }

        private decimal[] GetSplittedCalculusNumbers()
        {
            return Calculus.Split(new char[] { '+', '-', '*', '/' }).Select(n => n.ToDecimal()).ToArray();
        }

        private char[] GetSplittedCalculusOperators()
        {
            char[] operators = { '+', '-', '*', '/' };
            return Calculus.Where(c => operators.Contains(c)).ToArray();
        }

        private decimal GetResultFromOperator(char operand)
        {
            return operand switch
            {
                '+' => Add(),
                '-' => Substract(),
                '*' => Multiply(),
                '/' => Divide(),
                _ => throw new InvalidOperationException("Invalid operator.")
            };
        }

        public decimal EvaluateCalculus()
        {
            var numbers = GetSplittedCalculusNumbers();
            var operators = GetSplittedCalculusOperators();
            decimal result = 0;
            FirstNumber = numbers[0];
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                SecondNumber = numbers[i + 1];
                result = GetResultFromOperator(operators[i]);
                FirstNumber = result;
            }
            return result;
        }
    }
}
