using OpenQA.Selenium;

namespace TFLJourneyPlan.PageObjects
{
    public class JourneyPlannerPage
    {
        private readonly IWebDriver _driver;

        public JourneyPlannerPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement InputFrom => _driver.FindElement(By.CssSelector("#InputFrom"));
        public IWebElement InputTo => _driver.FindElement(By.CssSelector("#InputTo"));
        public IWebElement PlanJourneyButton => _driver.FindElement(By.CssSelector("#plan-journey-button"));
        public IWebElement EditPreferencesButton => _driver.FindElement(By.CssSelector(".toggle-options.more-options"));
        public IWebElement LeastWalkingOption => _driver.FindElement(By.CssSelector("label[for='JourneyPreference_2']"));
        public IWebElement UpdateJourneyButton => _driver.FindElement(By.CssSelector("div[id='more-journey-options'] div input[value='Update journey']"));
        public IWebElement WalkingJourneyTime => _driver.FindElement(By.CssSelector(".journey-box.walking"));
        public IWebElement CyclingJourneyTime => _driver.FindElement(By.CssSelector(".journey-box.cycling"));
        public IWebElement UpdatedJourneyTime => _driver.FindElement(By.CssSelector("div[id='option-1-heading'] div[class='clearfix time-boxes time-boxes-override']"));
        public IWebElement ViewDetailsButton => _driver.FindElement(By.CssSelector("div[id='option-1-content'] button.secondary-button.show-detailed-results.view-hide-details"));

        public void EnterText(IWebElement element, string text)
        {
            element.Clear(); // Clear the field before entering new text
            element.SendKeys(text);
        }

        public void ClickElement(IWebElement element)
        {
            element.Click();
        }
    }
}
