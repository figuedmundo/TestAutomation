using NUnit.Framework;
using System;
using TestAutomation.Report;

namespace TestAutomation.Evernote.TestCases.Base
{
    [SetUpFixture]
    public class SetupTest
    {
        [OneTimeSetUp]
        public void SetUpReporter()
        {
            ReportManager.Instance.Init();
        }

        [OneTimeTearDown]
        public void CloseReporter()
        {
            try
            {
                ReportManager.Instance.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}
