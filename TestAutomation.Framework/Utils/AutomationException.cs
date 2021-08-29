using System;
using TestAutomation.Framework.UiControl;

namespace TestAutomation.Framework.Utils
{
    public class AutomationException : Exception
    {
        public IControl Control { get; set; }
        private string _message;

        public AutomationException(string message)
            : base(message)
        {
            _message = message;
        }

        public AutomationException(string message, IControl control)
            : base(message)
        {
            _message = message;
            Control = control;
        }

        public AutomationException(string message, Exception innerException)
            : base(message, innerException)
        {
            _message = message;
        }

        public AutomationException(string message, IControl control, Exception innerException)
            : base(message, innerException)
        {
            _message = message;
            Control = control;
        }

        public override string Message
        {
            get
            {
                string message = _message;
                if (Control != null)
                {
                    message += "\n" + Control.ToString();
                }

                return message;
            }
        }
    }
}
