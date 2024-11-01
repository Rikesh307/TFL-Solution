# TFL Journey Planner Automation Framework

## Overview
This project implements a UI automation framework for testing the TfL Journey Planner. The framework is built using C#, NUnit, and Selenium WebDriver, focusing on the "Plan a journey" feature on the TfL website.

## Project Structure
- **Feature File**: Contains the Gherkin syntax scenarios for the journey planner functionality.
- **Step Definitions**: Implements the steps defined in the feature file using SpecFlow.
- **PageObjects**: Contains classes representing different pages of the application for better organization and maintainability.
- **Drivers**: Includes WebDriver setup and configuration for running tests.

## Development Decisions
1. **Reusable Code**: 
   - A `JourneyPlannerStepDefinitions` class was created to encapsulate common functionalities, such as WebDriver initialization, element waiting, clicking, and text entry. This promotes code reuse across multiple test classes.

2. **Page Object Model (POM)**:
   - The framework follows the Page Object Model design pattern, maintaining clean and organized code. Each page of the application is represented by a separate class, making updates easier to manage.

3. **SpecFlow Integration**:
   - SpecFlow is used for behavior-driven development (BDD), allowing the tests to be written in a human-readable format using Gherkin syntax. This enhances collaboration with non-technical stakeholders.

## Test Scenarios
The framework includes the following test scenarios:

### Positive Scenarios
1. **Plan a journey from Leicester Square to Covent Garden**:
   - Validates that the estimated walking and cycling journey times are displayed correctly.

2. **Edit Preferences For The Journey**:
   - Checks if the journey time updates correctly after selecting routes with the least walking.

3. **View Details for Covent Garden Underground Station**:
   - Verifies that the complete access information for the station is displayed.

### Negative Scenarios
1. **Invalid Journey Input**:
   - Ensures that an error message is displayed when an invalid starting point is entered.

2. **No Location Entered**:
   - Validates that an error message appears when no locations are specified.

3. **Both Starting and Destination Points Invalid**:
   - Checks for the correct error message when both input points are invalid.

### Additional Scenarios
#### Functional Testing Scenarios
1. **Verify Auto-Completion**:
   - Ensure that when typing in the starting or destination fields, suggestions are displayed, and valid options can be selected.

2. **Check for Minimum and Maximum Journey Time**:
   - Validate that the estimated journey times are within realistic limits (not negative or excessively high).

3. **Check Responsive Design**:
   - Verify that the journey planner is functional and visually coherent on different screen sizes (desktop, tablet, mobile).

4. **Accessibility Checks**:
   - Ensure that all interactive elements are accessible via keyboard navigation and are screen-reader friendly.

5. **Validate Error Handling**:
   - Check how the application handles unexpected inputs, such as special characters or excessively long strings.

#### Non-Functional Testing Scenarios
1. **Performance Testing**:
   - Measure the load time for the journey planner widget under different network conditions.

2. **Stress Testing**:
   - Simulate multiple users accessing the journey planner simultaneously to see how the system handles load.

3. **Security Testing**:
   - Verify that the application is secure against common vulnerabilities such as SQL injection and cross-site scripting (XSS).

4. **Usability Testing**:
   - Assess the user interface for intuitiveness and user-friendliness, ensuring users can navigate and use the journey planner effectively.

## Versions Used
- **.NET SDK**: 8.0.403
- **NUnit**: 3.13.2
- **Selenium WebDriver**: 4.26.0
- **Selenium ChromeDriver**: 130.0.6723.9100
- **SpecFlow**: 3.9.40
- **SpecFlow.NUnit**: 3.9.40

## Prerequisites
- Visual Studio 2022 or later with the necessary extensions for .NET development.
- An internet connection to access the TfL website during test execution.

## How to Run the Tests
1. Clone the repository to your local machine.
   ```bash
   git clone https://github.com/Rikesh307/TFL-Solution.git
   ```

2. Navigate to the project directory.
   ```bash
   cd TFL-Solution
   ```

3. Restore the project dependencies. This ensures that all the necessary NuGet packages are downloaded.
   ```bash
   dotnet restore
   ```

4. Set up the WebDriver. Ensure you have the Chrome browser installed, as the framework is configured to use ChromeDriver.
   - Download the appropriate version of ChromeDriver that matches your Chrome version from [ChromeDriver downloads](https://chromedriver.chromium.org/downloads).
   - Alternatively, you can manage your WebDriver through NuGet by adding the `Selenium.WebDriver.ChromeDriver` package to your project.

5. Configure Test Settings (if needed).
   - Modify any configurations required for your tests in the `appsettings.json` file or any relevant configuration files in your project.
   - Make sure to check if there are any necessary environment variables or settings related to the TfL website you need to configure.

6. Run the tests. Use the following command to execute all tests in the project:
   ```bash
   dotnet test
   ```
   This command runs all tests, and the results will be displayed in the console, indicating which tests passed or failed.

7. View Test Results. After the tests have run, you can see the summary of the results directly in the console. For a more detailed report, you can consider using the NUnit3TestAdapter in Visual Studio or generating reports using tools like ReportUnit.

8. Running Specific Tests (Optional). To run a specific test or a group of tests, you can use the `--filter` option:
   ```bash
   dotnet test --filter "FullyQualifiedName~YourTestName"
   ```
   Replace `YourTestName` with the name of the test you want to execute.

## Continuous Integration (Optional)
To automate test execution, you can set up a Continuous Integration (CI) pipeline using platforms like GitHub Actions or Azure DevOps. Create a `.yml` file in the `.github/workflows` directory to define the CI process that includes steps for restoring dependencies and running tests.

## Troubleshooting Tips
If you run into issues while executing the tests, check the following:
- Ensure that your ChromeDriver version matches your Chrome browser version.
- Verify that you have an active internet connection to access the TfL website.
- Check if your firewall or antivirus settings are blocking the test execution.
- Look for specific error messages in the console output for guidance on the issues.

## Further Testing Options
You can run tests in different environments or with different configurations to validate various aspects of the application, enhancing the robustness of your testing strategy.

### Logging and Debugging (Optional)
To assist with debugging, consider implementing logging within your tests to capture execution details, especially for failed tests. Use libraries like Serilog or NLog to log information to a file or other sinks for analysis.

### Running Tests in Headless Mode (Optional)
If you want to run tests without opening a browser window (headless mode), you can configure ChromeDriver to run in headless mode by modifying the WebDriver options in your test setup.
```csharp
var options = new ChromeOptions();
options.AddArgument("--headless");
// Add other options as needed
var driver = new ChromeDriver(options);
```

### Browser Configuration (Optional)
You can customize your Chrome browser settings by adding more arguments to `ChromeOptions`, such as:
- `--start-maximized` to start the browser in maximized mode.
- `--disable-gpu` to disable GPU hardware acceleration (useful for headless testing).
- `--no-sandbox` to avoid issues related to sandboxing in certain environments.

### Report Generation (Optional)
To generate test reports, you may want to integrate additional tools such as Allure or ExtentReports to create visually appealing reports after test execution. Set up the reporting framework in your project to capture test execution details and results.

### Parameterization (Optional)
To test various scenarios efficiently, consider using parameterized tests in NUnit. This allows you to run the same test with different inputs.
```
[TestCase("Leicester Square", "Covent Garden")]
[TestCase("Invalid Location", "Covent Garden")]
public void TestJourneyPlanner(string startLocation, string endLocation) {
    // Test implementation
}
```

### API Testing (Optional)
If the TfL Journey Planner has an API, consider writing additional tests to validate API responses, status codes, and data integrity.

### Cleanup After Tests (Optional)
Implement a cleanup mechanism to close the browser and release resources after test execution to prevent memory leaks or resource exhaustion.

### Running Tests in Parallel (Optional)
You can configure NUnit to run tests in parallel to speed up execution. Ensure that your tests are thread-safe before doing so.

### Stay Updated (Optional)
Regularly check for updates to your dependencies and the framework. Keeping everything up-to-date can help you leverage new features and improvements.

## Conclusion
The TFL Journey Planner Automation Framework provides a robust structure for testing the journey planning features on the TfL website. With the use of BDD principles, reusable components, and comprehensive test scenarios, the framework aims to ensure the quality and reliability of the journey planning functionality.
