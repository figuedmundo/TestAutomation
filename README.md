# Automation Framework Concept

Automation Framework project for UI / API test automation using Selenium, RestSharp and .NET core 3.1, the framework follows the Page Object Model pattern concepts.


**SUT:** [DemoQA](https://demoqa.com/)


**API Testing:** [PetStore](https://petstore.swagger.io/)

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

The Browser by default is Chrome and the ReportPath by default is the directory where the dlls are executed.
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

5. Open the **AutomationReport.html** from the path specified. (The path by default is *TestAutomation.TestCases/bin/Debug/netcoreapp3.1/AutomationReport.html*)

6. Enjoy!