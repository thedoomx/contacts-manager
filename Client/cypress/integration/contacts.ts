describe('Contacts', () => {
    beforeEach(() => {
      cy.visit('/contact');
    });
  
    it('has the correct title', () => {
      cy.title().should('equal', 'Angular Workshop: Counters');
    });
  });