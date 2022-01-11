using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SpecFlowCalculator
{
    public class Calculator
    {
        public string Calculation { get; set; }
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

        private decimal[] GetSplittedNumbersFromCalculation()
        {
            return Calculation.Split(new char[] { '+', '-', '*', '/' }).Select(n => n.ToDecimal()).ToArray();
        }

        private char[] GetSplittedOperatorsFromCalculation()
        {
            char[] operators = { '+', '-', '*', '/' };
            return Calculation.Where(c => operators.Contains(c)).ToArray();
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

        public decimal EvaluateCalculation()
        {
            var numbers = GetSplittedNumbersFromCalculation();
            var operators = GetSplittedOperatorsFromCalculation();
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
