using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using TFLJourneyPlan.PageObjects;

namespace TFLJourneyPlan.StepDefinitions
{
    [Binding]
    public sealed class JourneyPlannerStepDefinitions
    {
        private IWebDriver _driver = null!;
        private JourneyPlannerPage _journeyPlannerPage;

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            // Initialize the Chrome driver
            _driver = new ChromeDriver();

            // Maximize the browser window
            _driver.Manage().Window.Maximize();

            // Set implicit wait
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _journeyPlannerPage = new JourneyPlannerPage(_driver);
        }

        private IWebElement WaitForElement(By by, int timeoutInSeconds = 20)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(driver => driver.FindElement(by));
        }

        // Given step for landing on the Journey Planner page
        [Given(@"I am on the TfL Journey Planner page")]
        public void GivenIAmOnTheTfLJourneyPlannerPage()
        {
            _driver.Navigate().GoToUrl("https://tfl.gov.uk/plan-a-journey/?cid=plan-a-journey");
            AcceptCookiesIfPresent();
        }

        [When(@"I begin entering ""(.*)"" as the starting point")]
        public void WhenIBeginEnteringAsTheStartingPoint(string startingPoint)
        {
            _journeyPlannerPage.EnterText(_journeyPlannerPage.InputFrom, startingPoint);
            ClickSuggestion();
        }

        [When(@"I begin entering ""(.*)"" as the destination")]
        public void WhenIBeginEnteringAsTheDestination(string destination)
        {
            _journeyPlannerPage.EnterText(_journeyPlannerPage.InputTo, destination);
            ClickSuggestion();
        }

        private void ClickSuggestion()
        {
            var suggestion = WaitForElement(By.ClassName("tt-suggestion"));
            suggestion.Click();
        }

        [When(@"I click on Plan my journey")]
        public void WhenIClickOnPlanMyJourney()
        {
            var planJourneyButton = WaitForElement(By.Id("plan-journey-button"));
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(planJourneyButton));
            planJourneyButton.Click();
        }

        [Then(@"I should see the estimated (.*) journey time")]
        public void ThenIShouldSeeTheEstimatedJourneyTime(string journeyMode)
        {
            By journeyOptionSelector = journeyMode == "walking"
                ? By.CssSelector(".journey-box.walking")
                : By.CssSelector(".journey-box.cycling");

            var journeyOption = WaitForElement(journeyOptionSelector, 50);
            Assert.IsTrue(journeyOption.Displayed, $"{journeyMode} journey time is not displayed.");
        }

        [Given(@"I have planned a journey from ""(.*)"" to ""(.*)""")]
        public void GivenIHavePlannedAJourneyFromTo(string startLocation, string endLocation)
        {
            GivenIAmOnTheTfLJourneyPlannerPage();
            WhenIBeginEnteringAsTheStartingPoint(startLocation);
            WhenIBeginEnteringAsTheDestination(endLocation);
            WhenIClickOnPlanMyJourney();
        }

        [When(@"I click on ""(.*)""")]
        public void WhenIClickOn(string buttonName)
        {
            IWebElement button;
            switch (buttonName)
            {
                case "Edit preferences":
                    button = WaitForElement(By.CssSelector(".toggle-options.more-options"));
                    _journeyPlannerPage.ClickElement(button);
                    break;
                case "Update journey":
                    button = WaitForElement(By.CssSelector("div[id='more-journey-options'] div input[value='Update journey']"));
                    _journeyPlannerPage.ClickElement(button);
                    break;
                case "View Details":
                    System.Threading.Thread.Sleep(1000); // Wait for a short duration
                    button = WaitForElement(By.CssSelector("div[id='option-1-content'] button.secondary-button.show-detailed-results.view-hide-details"));
                    _journeyPlannerPage.ClickElement(button);
                    break;
                default:
                    throw new ArgumentException($"Button '{buttonName}' is not recognized.");
            }
        }

        [When(@"I select routes with least walking")]
        public void WhenISelectRoutesWithLeastWalking()
        {
            _journeyPlannerPage.ClickElement(WaitForElement(By.CssSelector("label[for='JourneyPreference_2']")));
        }

        [Then(@"I should see the updated journey time")]
        public void ThenIShouldSeeTheUpdatedJourneyTime()
        {
            var updatedTime = WaitForElement(By.CssSelector("div[id='option-1-heading'] div[class='clearfix time-boxes time-boxes-override']"));
            Assert.IsTrue(updatedTime.Displayed, "Updated journey time is not displayed.");
        }

        [Then(@"I should see complete access information at Covent Garden Underground Station")]
        public void ThenIShouldSeeCompleteAccessInformationAtCoventGardenUndergroundStation()
        {
            var accessInfo = WaitForElement(By.CssSelector("div.access-information"));
            Assert.IsTrue(accessInfo.Displayed, "Access information is not displayed.");
        }

        // Negative Test Scenarios
        [When(@"I enter an invalid starting point ""(.*)"" and a valid destination ""(.*)""")]
        public void WhenIEnterAnInvalidStartingPointAndAValidDestination(string invalidStartingPoint, string validDestination)
        {
            _journeyPlannerPage.EnterText(_journeyPlannerPage.InputFrom, invalidStartingPoint);
            _journeyPlannerPage.EnterText(_journeyPlannerPage.InputTo, validDestination);

            try
            {
                var suggestion = WaitForElement(By.ClassName("tt-suggestion"), 10);
                if (suggestion.Displayed)
                {
                    suggestion.Click();
                }
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("No suggestions appeared after entering the invalid starting point.");
            }
        }

        [Then(@"I should see an error message indicating the starting point is invalid")]
        public void ThenIShouldSeeAnErrorMessageIndicatingTheStartingPointIsInvalid()
        {
            try
            {
                var errorMessage = WaitForElement(By.ClassName("info-message"), 10);
                Assert.IsTrue(errorMessage.Text.Contains("We found more than one location matching"), "Expected error message not displayed.");
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Error message was not found.");
            }
        }

        [When(@"I do not enter any locations")]
        public void WhenIDoNotEnterAnyLocations()
        {
            // No action needed; we just won't enter any locations
        }

        [Then(@"I should see an error message indicating both locations are required")]
        public void ThenIShouldSeeAnErrorMessageIndicatingBothLocationsAreRequired()
        {
            var fromErrorMessage = WaitForElement(By.Id("InputFrom-error"));
            var toErrorMessage = WaitForElement(By.Id("InputTo-error"));
            Assert.IsTrue(fromErrorMessage.Displayed && toErrorMessage.Displayed, "Expected error messages not displayed.");
            Assert.IsTrue(fromErrorMessage.Text.Contains("The From field is required."), "Expected From error message not displayed.");
            Assert.IsTrue(toErrorMessage.Text.Contains("The To field is required."), "Expected To error message not displayed.");
        }

        [When(@"I enter an invalid starting point ""(.*)"" and an invalid destination ""(.*)""")]
        public void WhenIEnterAnInvalidStartingPointAndAnInvalidDestination(string invalidStartingPoint, string invalidDestination)
        {
            _journeyPlannerPage.EnterText(_journeyPlannerPage.InputFrom, invalidStartingPoint);
            _journeyPlannerPage.EnterText(_journeyPlannerPage.InputTo, invalidDestination);
        }

        [Then(@"I should see an error message saying ""(.*)""")]
        public void ThenIShouldSeeAnErrorMessageSaying(string expectedMessage)
        {
            var errorMessage = WaitForElement(By.CssSelector("li.field-validation-error"));
            Assert.IsTrue(errorMessage.Displayed, "Error message is not displayed.");
            Assert.AreEqual(expectedMessage, errorMessage.Text.Trim(), "The error message does not match the expected text.");
        }

        private void AcceptCookiesIfPresent()
        {
            try
            {
                var cookieButton = _driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
                if (cookieButton.Displayed)
                {
                    cookieButton.Click();
                }
            }
            catch (NoSuchElementException)
            {
                // The cookie banner is not present, so no action is needed
            }
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Quit();
        }
    }
}
