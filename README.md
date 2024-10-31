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
   - A `BaseTest` class was created to encapsulate common functionalities, such as WebDriver initialization, element waiting, clicking, and text entry. This promotes code reuse across multiple test classes.

2. **Page Object Model (POM)**:
   - The framework follows the Page Object Model design pattern, maintaining clean and organized code. Each page of the application is represented by a separate class, making updates easier to manage.

3. **SpecFlow Integration**:
   - SpecFlow is used for behavior-driven development (BDD), allowing the tests to be written in a human-readable format using Gherkin syntax. This enhances collaboration with non-technical stakeholders.

## Test Scenarios
The framework includes the following test scenarios:
- Verify that a valid journey can be planned from “Leicester Square Underground Station” to “Covent Garden Underground Station” and validate the estimated journey time for both walking and cycling.
- Edit preferences to select routes with the least walking and validate the updated journey time.
- View complete access information at Covent Garden Underground Station.

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

## Versions Used
- **.NET SDK**: 8.0.403
- **NUnit**: 3.13.2
- **Selenium WebDriver**: 4.25.0
- **Selenium ChromeDriver**: 130.0.6723.6900
- **SpecFlow**: 3.9.40
- **SpecFlow.NUnit**: 3.9.40

## Prerequisites
- Visual Studio 2022 or later with the necessary extensions for .NET development.
- An internet connection to access the TfL website during test execution.
