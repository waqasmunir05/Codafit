Feature: Broker Search
	In order to test the broker search functionality
	As a Tester 
	I want to search a broker and verify search feature

@mytag
Scenario: Search Broker from Dubailand website
	Given that I navigate to dubailand website
	And I press on Services
	And I press on Informatives
	And I press on General
	And I press on Licensed real estate brokers
	And I press on proceed to Service
	And I have entered Broker Name 
	When I press on Search 
    Then Broker search results appear
