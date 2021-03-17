using FluentAssertions;
using OpenQA.Selenium;
using SpecFlowProject.Helpers;
using System.Linq;
using TechTalk.SpecFlow;
using TestAutomationAcceptance.Helpers;
using TestAutomationAcceptance.Page;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class SearchSteps
    { 
        private readonly CommonSteps _commonSteps;

        public SearchSteps(CommonSteps commonSteps)
        {
            _commonSteps = commonSteps; 
        }


        [Given(@"enters search text (.*) in search field")]
        public void GivenEntersSearchTextInSearchField(string searchText)
        {
            _commonSteps.EnterTextField(SearchPage.SearchTextId, searchText);
        }

        [When(@"the user clicks Search Icon")]
        public void WhenTheUserClicksSearchIcon()
        {
            _commonSteps.Click(SearchPage.SearchIcon);
        }

        [When(@"the user clicks more link")]
        public void WhenTheUserClicksMoreLink()
        {
            _commonSteps.Click(SearchPage.MoreLink);
        }

        [Then(@"more results page is displayed")]
        public void ThenMoreResultsPageIsDisplayed()
        { 
            _commonSteps.VerifyNewWindowUrl(SearchPage.MoreLinkUrl).Should().BeTrue();
        }



        [When(@"the user clicks enter key")]
        public void WhenTheUserClicksEnterKey()
        {
            _commonSteps.EnterTextField(SearchPage.SearchTextId, Keys.Enter);
        }


        [Then(@"the (.*) text is displayed in (.*)")]
        [Then(@"(.*) text is displayed in (.*)")]
        [Then(@"the results for (.*) are displayed in (.*)")]
        public void ThenTheSearchResultsTextIsDisplayedInBold(string text, string style)
        {
            var isGreen = style == "green";
            var isBold = style == "bold";

            var locator = isGreen ? Locators.HrefText(text) : Locators.DivText(text) ;
            var property = isBold ? "font-weight" : "color";
            var result = isBold ? SearchPage.FontBold : isGreen ? SearchPage.ResultTextColor : SearchPage.NoResultFoundColor;

            _commonSteps.GetCssValue(locator, property).Should().Be(result);          
        }

         


    }
}
