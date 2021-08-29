using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomation.Report
{
    public static class Logger
    {
        public static void AddStep(string message)
        {
            ReportManager.Instance.SetStepStatusPass(message);
        }
    }
}
