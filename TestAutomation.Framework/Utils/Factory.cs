using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomation.Framework.Utils
{
    public static class Factory
    {
        /// <summary>
        /// Create an instance of a Page
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Page<T>()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
}
