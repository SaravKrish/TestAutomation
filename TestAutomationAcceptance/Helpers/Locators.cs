using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TestAutomationAcceptance.Helpers
{
    public static class Locators
    {
        public static By DivText(string message) => By.XPath($"//div[contains(text(),'{message}')]");

        public static By HrefText(string message) => By.XPath($"//a[contains(text(),'{message}')]");

        public static By LabelFor(string message) => By.XPath($"//label[@for='{message}']");
    }
}
