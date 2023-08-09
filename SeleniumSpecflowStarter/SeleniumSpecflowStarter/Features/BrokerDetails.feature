Feature: To check functionality of Broker details
AS A Tester
	I want to test broker details are correct

@mytag
Scenario: I am on brokers list and search a broker to view broker details
	Given I am on brokers list
	And I entered broker name
	And I press search button
	When I select broker
	Then broker details page should open
	Then I verify broker number is correct
	Then I Verify broker card issue date is correct
	And I Click on Office Tab
	Then I Verify Office Number is correct
	Then I verify broker office activity is correct
	And I click broker transactions tab
	Then broker transactions counted correctly
	And I Click on Projects
	Then I verify Projects count
	And I Click on Ranking tab
	Then I verify Broker Rank points
	When I click on Awards tab
	Then I verify Broker Award
	Then I close Browser



	Scenario: Search Broker with valid Broker Number
	Given I am on brokers list
	And I Enter valid broker number
	And I press search button
	When I select broker
	Then broker details page should open
	Then I verify broker number is correct
	Then I Verify broker card issue date is correct
	And I Click on Office Tab
	Then I Verify Office Number is correct
	Then I verify broker office activity is correct
	And I click broker transactions tab
	Then broker transactions counted correctly
	And I Click on Projects
	Then I verify Projects count
	And I Click on Ranking tab
	Then I verify Broker Rank points
	When I click on Awards tab
	Then I verify Broker Award
	Then I close Browser


	Scenario: Search Broker with valid Mobile Number
	Given I am on brokers list
	And I enter valid Broker Mobile Number
	And I press search button
	When I select broker
	Then broker details page should open
	Then I verify broker number is correct
	Then I Verify broker card issue date is correct
	And I Click on Office Tab
	Then I Verify Office Number is correct
	Then I verify broker office activity is correct
	And I click broker transactions tab
	Then broker transactions counted correctly
	And I Click on Projects
	Then I verify Projects count
	And I Click on Ranking tab
	Then I verify Broker Rank points
	When I click on Awards tab
	Then I verify Broker Award
	Then I close Browser

	Scenario: Search Broker by valid Area Name
	Given I am on brokers list
	And I enter valid Area Name
	And I press search button
	When I select broker
	Then broker details page should open
	Then I verify broker number is correct
	Then I Verify broker card issue date is correct
	And I Click on Office Tab
	Then I Verify Office Number is correct
	Then I verify broker office activity is correct
	And I click broker transactions tab
	Then broker transactions counted correctly
	And I Click on Projects
	Then I verify Projects count
	And I Click on Ranking tab
	Then I verify Broker Rank points
	When I click on Awards tab
	Then I verify Broker Award
	Then I close Browser
