Feature: Create Character
  
  Scenario: Create Default Character
    Given I have not created any characters
    When I create a default character
    Then I should see my character in the world