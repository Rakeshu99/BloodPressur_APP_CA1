Feature: Blood Pressure Classification
  As a user
  I want to know my blood pressure category
  So that I can understand my health status

  Scenario: High blood pressure when systolic is high
    Given the systolic value is 150
    And the diastolic value is 70
    When I calculate the blood pressure category
    Then the category should be "High"

  Scenario: Pre-high blood pressure
    Given the systolic value is 130
    And the diastolic value is 85
    When I calculate the blood pressure category
    Then the category should be "PreHigh"

  Scenario: Ideal blood pressure
    Given the systolic value is 110
    And the diastolic value is 75
    When I calculate the blood pressure category
    Then the category should be "Ideal"

  Scenario: Low blood pressure
    Given the systolic value is 80
    And the diastolic value is 55
    When I calculate the blood pressure category
    Then the category should be "Low"
