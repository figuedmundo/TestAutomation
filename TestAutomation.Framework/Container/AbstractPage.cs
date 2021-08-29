using System;
using System.Collections.Generic;
using System.Text;
using TestAutomation.Framework.Utils;

namespace TestAutomation.Framework.Container
{
    public abstract class AbstractPage
    {
        public AbstractPage()
        {
            SeleniumActions.SwitchToDefaultContent();
        }
    }
}
