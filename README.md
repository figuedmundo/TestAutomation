# Automation Framework Concept

Automation Framework project for UI / API test automation using Selenium, RestSharp and .NET core 3.1, the framework follows the Page Object Model pattern concepts.


**SUT:** [DemoQA](https://demoqa.com/)


**API Testing:** [PetStore](https://petstore.swagger.io/)

## CI/CD

The repository is integrated with a CI/CD github actions pipeline.

1. Go to the repository Actions page https://github.com/figuedmundo/TestAutomation/actions
2. In the workflows tree Click on Testing pipeline
3. Click Run Workflow menu button 
4. Click Run Workflow button

This will trigger the action and the results can be reviewed in Calliope.Pro in the following address:

  - https://app.calliope.pro/profiles/3587

To enter to the dashboard you can use the following credentials

  - email: tester.automation.framework@gmail.com
  - password: Control123!

## Requirements

* Chrome Browser
* [.NET Core 3.1](https://dotnet.microsoft.com/download)

## Configuration File

The configuration file is `appsettings.json`. It is located in **TestAutomation.Testcases** project.


```javascript
{
  "Browser": "Chrome",
  "ReportPath":  "/Users/<userName>/"
}
```

The Browser by default is Chrome and the ReportPath by default is "TestAutomation.TestCases/TestResults/".
To set up the Report Path make sure that the user has write privileges.

## Usage

1. Clone the repository

```
$ git clone https://github.com/figuedmundo/TestAutomation.git
```
2. Configure Report Path (Optional)

3. Build the projects

```
$ cd TestAutomation
$ dotnet build
```

4. Execute the Test Cases

```
$ dotnet test TestAutomation.TestCases/TestAutomation.TestCases.csproj
```

5. Open the **AutomationReport.html** from the path specified. (The path by default is *TestAutomation.TestCases/TestResults/AutomationReport.html*)

6. Enjoy!


## Next Steps

The next step for the framework would be implement BDD with the help of SpecFlow

