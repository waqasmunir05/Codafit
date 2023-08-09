Feature: Youtube search Feature
	In order to test search feature of youtube
	As a Tester
	I want to test if the feature is working correctly

@mytag
Scenario: Youtube should search for the given keyword and should navigate to search
	Given I have navigated to youtube website
	And I have entered Pakistan as search keyword
	When I press the search button
	Then I should be navigated to search results page
