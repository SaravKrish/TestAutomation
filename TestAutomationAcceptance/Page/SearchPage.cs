
using OpenQA.Selenium;
using TestAutomationAcceptance.Helpers;

namespace TestAutomationAcceptance.Page
{
    public static class SearchPage
    {
        public static By SearchTextId => By.Id("Wikipedia1_wikipedia-search-input");
        public static By SearchIcon => By.ClassName("wikipedia-search-button");

        public static By MoreLink => Locators.HrefText("More »");

        public static string MoreLinkUrl => "https://en.wikipedia.org/w/index.php?title";
        public static string NoResultFoundColor => "rgba(221, 75, 57, 1)";
        public static string ResultTextColor => "rgba(178, 171, 39, 1)";
        public static string FontBold => "700";

        public static object Locator { get; private set; }
    }
}
