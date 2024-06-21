using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoapiKontaktyTest
{
    public static class Knihovna
    {
        public static void Click(IWebElement locator)
        { locator.Click(); }

        public static void ClickElement(this IWebElement locator)
        { locator.Click(); }
        public static void EnterText(IWebElement locator, string text) {
            locator.Clear();
            locator.SendKeys(text);
        }

        // extension method
        public static void EnterTextEM(this IWebElement locator, string text)
        {
            locator.Clear();
            locator.SendKeys(text);
        }
    }
}
