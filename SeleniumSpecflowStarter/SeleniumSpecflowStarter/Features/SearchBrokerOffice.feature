Feature: Search Broker Office functionality

@mytag
Scenario: Search Broker Office with valid Office Name
	Given I am on office list
	And I enter valid office name
	When I Click on search button
	And I Click on Office Card
	Then Office Details are loaded
	Then I verify Office Name
	Then I verify Office Number
	Then I verify office Activity
	When I click on Brokers tab
	Then Brokers list is loaded
	Then I verify Brokers count
	When I Click on Ranking tab
	Then I verify office rank points
	When I click on office Awards tab
	Then I verify awards





