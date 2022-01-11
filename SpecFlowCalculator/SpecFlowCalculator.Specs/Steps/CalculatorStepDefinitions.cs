using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowCalculator.Specs.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        private readonly Calculator _calculator = new Calculator();
        private readonly ScenarioContext _scenarioContext;
        private decimal _result; 
        private Exception _actualException;

        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            _calculator.FirstNumber = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            _calculator.SecondNumber = number;
        }

        [Given(@"the calculus is (.*)")]
        public void GivenTheCalculusIs_(string calculus)
        {
            _calculator.Calculus = calculus;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _result = _calculator.Add();
        }
        
        [When("the two numbers are multiplied")]
        public void WhenTheTwoNumbersAreMultiplied()
        {
            _result = _calculator.Multiply();
        }

        [When("the first number is divided by the second")]
        public void WhenTheFirstNumberIsDividedByTheSecond()
        {
            try
            {
                _result = _calculator.Divide();
            }
            catch (DivideByZeroException e)
            {
                _actualException = e;
            }
        }


        [When(@"the calculus is evaluated")]
        public void WhenTheCalculusIsEvaluated()
        {
            try
            {
                _result = _calculator.EvaluateCalculus();
            }
            catch(Exception e)
            {
                _actualException = e;
            }
        }


        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            _result.Should().Be(result);
        }

        [Then("the error message '(.*)' should be raised")]
        public void ThenTheResultShouldBe(string result)
        {
            _actualException.Message.Should().Be(result);
        }
    }
}
