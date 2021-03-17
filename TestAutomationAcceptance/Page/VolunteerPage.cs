using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestAutomationAcceptance.Enums;
using TestAutomationAcceptance.Helpers;

namespace TestAutomationAcceptance.Page
{
    public static class VolunteerPage
    {
        public static By InputField(Field name) => By.Id($"RESULT_TextField-{(int)name}");
        public static By FileUpload => By.Id($"RESULT_FileUpload-10");
        public static By RadioButton(Sex name) => Locators.LabelFor($"RESULT_RadioButton-7_{(int)name}");
        public static By CheckBox(Day name) => Locators.LabelFor($"RESULT_CheckBox-8_{(int)name}");
        public static By IFrame => By.Id("frame-one1434677811");
        public static By ContactTime => By.Id("RESULT_RadioButton-9");
        public static By SubmitButton => By.Id("FSsubmit");
        public static By ErrorMessage => Locators.DivText("An error has occurred");
        public static string EmailValidationMessage(string email)
        {
            if (email.Contains("@@"))
            {
                return "A part following '@' should not contain the symbol '@'.";
            }
            else if (email.EndsWith("@"))
            {
                return $"Please enter a part following '@'. '{email}' is incomplete.";
            }

            return $"Please include an '@' in the email address. '{email}' is missing an '@'.";
        }

        public static string ValidationMessage(string property) => $"Please enter valid {property}.";
    }
}
