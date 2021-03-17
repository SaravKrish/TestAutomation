using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class CommonSteps
    {
        string pageUrl = "http://testautomationpractice.blogspot.com/";
        public IWebDriver Driver;

        public CommonSteps()
        {
            Driver = new ChromeDriver();
        }

        [Given(@"the user has progressed to testautomation page")]
        public void GivenTheUserHasProgressedToTestautomationPage()
        {
            Driver.Url = pageUrl;
            Driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(2000);
        }

        public void SwitchToFrame(By frame)
        {
            var element = Driver.FindElement(frame);
            Driver.SwitchTo().Frame(element);
        }

        public void EnterTextField(By textField,string text, bool clear = false)
        {
            if(clear)
            {
                Driver.WaitUntilElementExists(textField).Clear();
            }
            Driver.WaitUntilElementExists(textField).SendKeys(text);
        }

        public string GetValidationMessage(By field)
        {
            return Driver.FindElement(field).GetAttribute("validationMessage");
        }

        public void Click(By field)
        {
            Driver.FindElement(field).Click();
        }

        public string GetCssValue(By field,string property)
        {
            return Driver.WaitUntilElementExists(field).GetCssValue(property);
        }

        public bool ElementExists(By field)
        {
            return Driver.WaitUntilElementExists(field).Displayed;
        }

        public bool VerifyNewWindowUrl(string url)
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            return Driver.Url.Contains(url);
        }

        public bool ElementVisible(By field)
        {
            return Driver.WaitUntilVisible(field).Displayed;
        }

        [AfterScenario]
        public void QuitDriver()
        {
            Driver.Quit();
        }

    }
}
