using FluentAssertions;
using TechTalk.SpecFlow;
using TestAutomationAcceptance.Enums;
using TestAutomationAcceptance.Helpers;
using TestAutomationAcceptance.Page;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class VolunteerFormSteps
    {
        private CommonSteps _commonSteps;
          


        public VolunteerFormSteps(CommonSteps commonSteps)
        {
            _commonSteps = commonSteps;
        }

        [Given(@"fills volunteer form")]
        public void GivenFillsVolunteerForm()
        {
            FillForm();
        }



        private void FillForm(string email=null)
        {
            _commonSteps.SwitchToFrame(VolunteerPage.IFrame);
            _commonSteps.EnterTextField(VolunteerPage.InputField(Field.FirstName), Faker.Name.First());
            _commonSteps.EnterTextField(VolunteerPage.InputField(Field.LastName), Faker.Name.Last());
            _commonSteps.EnterTextField(VolunteerPage.InputField(Field.Phone), Faker.Phone.Number());
            _commonSteps.EnterTextField(VolunteerPage.InputField(Field.Country), Faker.Country.Name());
            _commonSteps.EnterTextField(VolunteerPage.InputField(Field.City), Faker.Address.City());
            _commonSteps.EnterTextField(VolunteerPage.InputField(Field.EmailAddress), !string.IsNullOrEmpty(email) ? email: Faker.Internet.Email());
            _commonSteps.Click(VolunteerPage.RadioButton(Sex.Female));
            _commonSteps.Click(VolunteerPage.CheckBox(Day.Monday));
            _commonSteps.Click(VolunteerPage.CheckBox(Day.Wednesday));
            _commonSteps.Click(VolunteerPage.CheckBox(Day.Friday));
            _commonSteps.EnterTextField(VolunteerPage.ContactTime, "Afternoon");
        }

        [Given(@"fills volunteer form with (.*) (.*)")]
        public void GivenFillsVolunteerFormWithFirstnameInvalid(string property, string value)
        {
            FillForm(); 
            _commonSteps.EnterTextField(VolunteerPage.InputField(property.ToField()), value, true);
        }

        [Then(@"the (.*) validation message should be displayed")]
        public void ThenTheFirstNameValidationMessageShouldBeDisplayed(string property)
        {
            _commonSteps.GetValidationMessage(VolunteerPage.InputField(property.ToField())).Should().Be(VolunteerPage.ValidationMessage(property));
        }


        [When(@"the user uploads the file")]
        public void WhenTheUserUploadsTheFile()
        {
            var fileName = "TestFile.txt";
            _commonSteps.EnterTextField(VolunteerPage.FileUpload, fileName.GetFilePath());
        }


        [When(@"the user submits the form")]
        public void WhenTheUserSubmitsTheForm()
        {
            _commonSteps.Click(VolunteerPage.SubmitButton);
        }

        [Then(@"the email validation message should be displayed for (.*)")]
        public void ThenTheEmailValidationMessageShouldBeDisplayedFor(string email)
        {
            _commonSteps.GetValidationMessage(VolunteerPage.InputField(Field.EmailAddress)).Should().Be(VolunteerPage.EmailValidationMessage(email));
        }


        [Then(@"the message should be displayed")]
        public void ThenTheMessageShouldBeDisplayed()
        {
            _commonSteps.ElementVisible(VolunteerPage.ErrorMessage).Should().BeTrue();
        }

    }
}
