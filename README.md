## TaxCalculatorUI

This branch further extends the work done on [ConsoleAppEnhancements](https://github.com/Chris-Filiatrault/coding-assignment/tree/ConsoleAppEnhancements) by adding a Razor Pages UI and publishing to Azure, link to site [here](https://tax-calculator-ui.azurewebsites.net/).

Primary changes on this branch include include:

- Creating a new Razor Pages project
- Bringing over files from the original project
- Refactoring/removing console application specific code
- Consolidating functions into two files (Calculations.cs, and Utilities.cs)
- Building the pages and input form
- Creating a *Values* class in the models folder to capture values from the form