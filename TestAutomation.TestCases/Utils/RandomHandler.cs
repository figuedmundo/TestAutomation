using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomation.TestCases.Utils
{
    public class RandomHandler
    {
        public static Bogus.Faker Faker => new Bogus.Faker("en");
    }
}
