using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestAutomation.Pages.Demoqa;
using TestAutomation.Pages.Demoqa.Interactions;
using TestAutomation.TestCases.Base;

namespace TestAutomation.TestCases.UiTestCasess.Demoqa
{
    public class InteractionsTestCases : DemoqaTest
    {
        [Test]
        [Ignore("exit")]
        public void TestListSortable()
        {
            var expectedList = new List<string>()
            {
                Number.One,
                Number.Four,
                Number.Two,
                Number.Three,
                Number.Five,
                Number.Six
            };

            IndexPage
                .InteractionsButton.Click()

                .GoTo.LeftNavigationBar
                .Menu(MenuOption.Sortable).Click()

                .GoTo.SortablePage
                .MoveElementOver(Number.Four, Number.Two)
                .AssertListOrder(expectedList);
        }
    }
}
