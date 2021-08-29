using System;
using System.Collections.Generic;
using System.Text;
using TestAutomation.ApiManager;
using TestAutomation.TestCases.Utils;

namespace TestAutomation.TestCases.UiTestCases.Demoqa
{
    public class Precondition
    {
        public static void CreateUser(UserData user)
        {
            var restHandler = new RestHandler("https://demoqa.com/Account/v1/");

            restHandler.Post<UserData>("User", user);
        }
    }
}
