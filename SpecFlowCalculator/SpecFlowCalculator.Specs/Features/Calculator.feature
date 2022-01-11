Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowCalculator.Specs/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@addition
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@multiplication
Scenario: Multiply two numbers
	Given the first number is 5
	And the second number is 7
	When the two numbers are multiplied
	Then the result should be 35

@division
Scenario: Divide two numbers
	Given the first number is 50
	And the second number is 10
	When the first number is divided by the second
	Then the result should be 5

@division
Scenario: Divide by 0
	Given the first number is 5
	And the second number is 0
	When the first number is divided by the second
	Then the error message 'Attempted to divide by zero.' should be raised

@completeCalcul
Scenario: Calculation with more than 1 operator
	Given the calculation is <Calculation>
	When the calculation is evaluated
	Then the result should be <Result>
Examples: 
| Calculation | Result |
| 10*5-2      | 48     |
| 10/2+5      | 10     |

@completeCalcul
Scenario: Calculation contains one invalid operator
	Given the calculation is 3*5$0
	When the calculation is evaluated
	Then the error message 'Invalid operation.' should be raised
	
@completeCalcul
Scenario: Calculation contains one division by 0
	Given the calculation is 3*5/0
	When the calculation is evaluated
	Then the error message 'Attempted to divide by zero.' should be raised