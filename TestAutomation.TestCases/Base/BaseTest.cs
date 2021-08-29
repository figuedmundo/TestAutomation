using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using TestAutomation.Evernote.TestCases.Base;
using TestAutomation.Framework.Browser;
using TestAutomation.Report;

namespace TestAutomation.TestCases.Base
{
    [TestFixture]
    public class BaseTest : SetupTest
    {
        [SetUp]
        public void MyTestInitialize()
        {
            try
            {
                // start logger
                ReportManager.Instance.CreateTest(TestContext.CurrentContext.Test.Name);

                // Test Init
                BrowserManager.Instance.Init();
                //BrowserManager.Instance.Visit(Settings.AppUrl);
            }
            catch (Exception ex)
            {
                var errorMessage = $"{ex.Message} :: {ex.StackTrace}";
                throw new Exception(errorMessage);
            }
        }

        [TearDown]
        public void MyTestCleanup()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = TestContext.CurrentContext.Result.StackTrace;
                var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";

                switch (status)
                {
                    case TestStatus.Failed:
                        ReportManager.Instance.SetTestStatusFail($"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                        ReportManager.Instance.AddTestFailureScreenshot(BrowserManager.Instance.ScreenCaptureAsBase64String());
                        break;
                    case TestStatus.Skipped:
                        ReportManager.Instance.SetTestStatusSkipped();
                        break;
                    default:
                        ReportManager.Instance.SetTestStatusPass();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Test Clean up
                BrowserManager.Instance.Quit();
            }
        }


    }
}
