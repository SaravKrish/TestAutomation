using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowProject.Helpers
{
    public static class DriverExtension
    {
        public static IWebElement WaitUntilElementExists(this IWebDriver driver, By elementLocator, int timeout = 20)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementExists(elementLocator));
            }
            catch (NoSuchElementException ex)
            {
                throw new NoSuchElementException($"Element with locator: '{elementLocator}' was not found in current context page.", ex);
            }
        }

        public static IWebElement WaitUntilElementClickable(this IWebDriver driver, By elementLocator, int timeout = 20)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (NoSuchElementException ex)
            {
                throw new NoSuchElementException($"Element with locator: '{elementLocator}' was not found in current context page.", ex);
            }
        }


        public static IWebElement WaitUntilVisible(this IWebDriver driver, By elementLocator, int timeout = 30)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
            }
            catch (NoSuchElementException ex)
            {
                throw new NoSuchElementException($"Element with locator: '{elementLocator}' was not found in current context page.", ex);
            }
        }
    }
}
