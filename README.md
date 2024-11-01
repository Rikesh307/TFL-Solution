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
