Feature: Goto Contact page from main Menu of HomePage

This feature verifies user can navigate correctly from Homepage to Contact Us Page.

@FromHomePage
Scenario: Navigate from Homepage to Contact Us page from the main Menu
	Given User is on Homepage
	When User Clicks on Contact button on the main Menu
	Then User is navigated to Contact Page successfully


@FromBanner
Scenario: Navigate from Homepage to Contact Us page from Banner
	Given User is on Homepage
	When User Clicks on Contact button on the Banner
	Then User is navigated to Contact Page successfully