import { Given, When, Then } from 'cypress-cucumber-preprocessor/steps';

Given(/^I have not created any characters$/, () => {
    cy.visit('/');
    cy.getByTestId('start-game-button').click();
});

When(/^I create a default character$/, () => {
    cy.getByTestId('character-name-input').type('Aragorn');
    cy.getByTestId('create-character-button').click();
});

Then(/^I should see my character in the world$/, () => {
    cy.getByTestId('character').should('be.visible');
    cy.getByTestId('character').should('have.contain', 'Aragorn');
});