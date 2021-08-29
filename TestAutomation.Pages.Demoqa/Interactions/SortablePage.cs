using System.Collections.Generic;
using System.Linq;
using TestAutomation.Framework.Container;
using TestAutomation.Framework.Core;
using TestAutomation.Framework.UiControl;
using TestAutomation.Framework.Utils;
using TestAutomation.Report;

namespace TestAutomation.Pages.Demoqa.Interactions
{
    public class SortablePage : AbstractPage
    {
        public Control<SortablePage> ListGridElement(string number) =>
             new Control<SortablePage>(this, Locator.XPath,
                 $"//div[contains(@class,'vertical-list-container')]//div[contains(@class,'list-group-item')][text()='{number}']", number);

        public SortablePage MoveElementOver(string numberA, string numberB)
        {
            ListGridElement(numberA).DragAndDrop(ListGridElement(numberB));

            return this;
        }

        public SortablePage AssertListOrder(List<string> expectedList)
        {
            var listElement = new Control<SortablePage>(Locator.XPath,
                 $"//div[contains(@class,'vertical-list-container')]//div[contains(@class,'list-group-item')]", "List");

            var actualList = listElement.Elements.Select(el => el.Text).ToList();

            if (actualList.SequenceEqual(expectedList))
            {
                Logger.AddStep($"Sortable List is equal to [{string.Join(", ", actualList)}]");
            }
            else
            {
                throw new AutomationException($"Sortable List should be equal to [{string.Join(", ", expectedList)}], " +
                    $"but actual List is [{string.Join(", ", actualList)}]");
            }

            return this;
        }
    }

    public struct Number
    {
        public const string One = "One";
        public const string Two = "Two";
        public const string Three = "Three";
        public const string Four = "Four";
        public const string Five = "Five";
        public const string Six = "Six";
        public const string Seven = "Seven";
        public const string Eight = "Eight";
        public const string Nine = "Nine";
    }
}
