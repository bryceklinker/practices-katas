import { Given, When, Then } from 'cypress-cucumber-preprocessor/steps';

Given(/^I have not created any characters$/, () => {
    cy.visit('/');
    cy.getByTestId('start-game-button').click();
});

When(/^I create a default character$/, () => {
});

Then(/^I should see my character in the world$/, () => {
    
});