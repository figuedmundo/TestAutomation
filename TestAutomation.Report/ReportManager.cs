using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;
using System.Reflection;
using TestAutomation.Configuration;

namespace TestAutomation.Report
{
    public class ReportManager
    {
        public AventStack.ExtentReports.ExtentReports Extent { get; set; }
        public ExtentV3HtmlReporter Reporter { get; set; }
        public ExtentTest Test { get; set; }
        
        private string timeStamp;

        private static ReportManager _instance;
        public static ReportManager Instance => _instance ??= new ReportManager();

        public ReportManager()
        {
            timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
        }

        public void Init()
        {
            var path = Settings.ReportPath;
            string reportPath = !string.IsNullOrEmpty(path)
                ? path
                : Path.Combine(AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin")), "TestResults");

            Reporter = new ExtentV3HtmlReporter(Path.Combine(reportPath, $"AutomationReport{timeStamp}.html"));
            Reporter.Config.DocumentTitle = "Test Automation Report";
            Reporter.Config.ReportName = "Regression Testing";
            Reporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            Extent = new AventStack.ExtentReports.ExtentReports();
            Extent.AttachReporter(Reporter);
            Extent.AddSystemInfo("Application Under Test", "Test Automation");
            Extent.AddSystemInfo("Environment", "QA");
            Extent.AddSystemInfo("Machine", Environment.MachineName);
            Extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
        }

        public void CreateTest(string testName)
        {
            Test = Extent.CreateTest(testName);
        }

        public void SetStepStatusPass(string stepDescription)
        {
            Test.Log(Status.Pass, stepDescription);
        }
        public void SetStepStatusWarning(string stepDescription)
        {
            Test.Log(Status.Warning, stepDescription);
        }
        public void SetStepStatusInformation(string stepDescription)
        {
            Test.Log(Status.Info, stepDescription);
        }
        public void SetStepStatusFail(string stepDescription)
        {
            Test.Log(Status.Fail, stepDescription);
        }
        public void SetTestStatusPass()
        {
            Test.Pass("Test Executed Sucessfully!");
        }
        public void SetTestStatusFail(string message = null)
        {
            var printMessage = "<p><b>Test FAILED!</b></p>";
            if (!string.IsNullOrEmpty(message))
            {
                printMessage += $"Message: <br>{message}<br>";
            }
            Test.Fail(printMessage);
        }
        public void AddTestFailureScreenshot(string base64ScreenCapture)
        {
            Test.AddScreenCaptureFromBase64String(base64ScreenCapture, "Screenshot on Error:");
        }
        public void SetTestStatusSkipped()
        {
            Test.Skip("Test skipped!");
        }
        public void Close()
        {
            Extent.Flush();
        }
    }
}
