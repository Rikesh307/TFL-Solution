Feature: TfL Journey Planner 
  As a user
  I want to plan a journey using the TfL Journey Planner
  So that I can find the best route between two locations

  # Positive Scenarios
  Scenario: Plan a journey from Leicester Square to Covent Garden
    Given I am on the TfL Journey Planner page
    When I begin entering "Leicester Square" as the starting point
    And I begin entering "Covent Garden" as the destination
    And I click on Plan my journey
    Then I should see the estimated walking journey time
    And I should see the estimated cycling journey time

  Scenario: Edit Preferences For The Journey
    Given I have planned a journey from "Leicester Square" to "Covent Garden"
    When I click on "Edit preferences"
    And I select routes with least walking
    And I click on "Update journey"
    Then I should see the updated journey time

  Scenario: View details for Covent Garden Underground Station
    Given I have planned a journey from "Leicester Square" to "Covent Garden"
    When I click on "Edit preferences"
    And I select routes with least walking
    And I click on "Update journey"
    Then I should see the updated journey time
    When I click on "View Details"
    Then I should see complete access information at Covent Garden Underground Station

  # Negative Scenarios
  Scenario: Verify that the widget does not provide results when an invalid journey is planned
    Given I am on the TfL Journey Planner page
    When I enter an invalid starting point "lululululu" and a valid destination "Covent Garden Underground"
    And I click on Plan my journey
    Then I should see an error message indicating the starting point is invalid

  Scenario: Verify that the widget is unable to plan a journey if no locations are entered
    Given I am on the TfL Journey Planner page
    When I do not enter any locations
    And I click on Plan my journey
    Then I should see an error message indicating both locations are required

  Scenario: Verify journey planning when both starting and destination points are invalid
    Given I am on the TfL Journey Planner page
    When I enter an invalid starting point "---" and an invalid destination "@@@"
    And I click on Plan my journey
    Then I should see an error message saying "Sorry, we can't find a journey matching your criteria"
