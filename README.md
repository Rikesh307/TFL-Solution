# TFL-Solution

## Overview
This project implements a UI automation framework for testing the TfL Journey Planner. The framework is built using C#, NUnit, and Selenium WebDriver, focusing on the "Plan a journey" feature on the TfL website.
## Project Structure
- **Tests**: Contains all the test classes.
- **PageObjects**: Houses the page object classes that represent various pages of the TfL Journey Planner.
- **Drivers**: Includes WebDriver setup and configuration.
- **Resources**: Contains any additional resources needed for testing, such as JSON or XML files for test data.
## Development Decisions
1. **Reusable Code**: 
   - Created a `BaseTest` class to encapsulate common functionalities such as WebDriver initialization, element waiting, clicking, and text entry. This promotes code reuse across multiple test classes.
2. **Page Object Model**:
   - The framework follows the Page Object Model (POM) design pattern to maintain clean and organized code. Each page of the application is represented by a separate class, making updates easier to manage.
3. **Modular Test Design**:
   - Tests are organized into separate classes based on functionality. Each class contains multiple related test scenarios, allowing for easier expansion and maintenance.
4. **Cross-Browser Testing**:
   - Designed to support multiple browsers by using WebDriver’s built-in capabilities, enabling tests to run on Chrome, Firefox, and Edge.
## Test Scenarios
- Verify that a valid journey can be planned from “Leicester Square Underground Station” to “Covent Garden Underground Station”.
- Validate the estimated journey time for both walking and cycling.
## Versions Used
- **.NET SDK**: 8.0.403
- **NUnit**: 3.13.2
- **Selenium WebDriver**: 4.25.0
- **Selenium ChromeDriver**: 130.0.6723.6900
- **SpecFlow**: 3.9.40
- **SpecFlow.NUnit**: 3.9.40
## Prerequisites
- Visual Studio 2022 or later with the necessary extensions for .NET development.
- Internet connection to access the TfL website during test execution.
## How to Run the Tests
1. Clone the repository to your local machine.
   ```bash
   git clone https://github.com/Rikesh307/TFLJourneyPlan.git
