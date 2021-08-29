using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TestAutomation.Framework.UiControl;
using TestAutomation.Framework.Utils;

namespace TestAutomation.Framework.Core
{
    [Flags]
    public enum PostAction
    {
        None = 0,
        PageLoadComplete = 1,
        SendEnter = 2,
        SendTab = 3,
        Sleep = 4,
        SwithToDefaultContent = 5
    }

    public static class ControlPostAction
    {
        public static void ManagePostAction(PostAction[] postActions, IControl control)
        {
            if (postActions != null && postActions.Any() && !postActions.Any(p => p.Equals(PostAction.None)))
            {
                var postActionsMethods = new Dictionary<PostAction, Action>
                {
                    { PostAction.PageLoadComplete, () => SeleniumActions.PageLoadComplete() },
                    { PostAction.SendEnter, () => control.Element.SendKeys(Keys.Enter) },
                    { PostAction.SendTab, () => control.Element.SendKeys(Keys.Tab) },
                    { PostAction.Sleep, () => SeleniumActions.Sleep() },
                    { PostAction.SwithToDefaultContent, () => SeleniumActions.SwitchToDefaultContent() }
                };

                foreach (var action in postActions)
                {
                    postActionsMethods[action].Invoke();
                }
            }
        }
    }
}
