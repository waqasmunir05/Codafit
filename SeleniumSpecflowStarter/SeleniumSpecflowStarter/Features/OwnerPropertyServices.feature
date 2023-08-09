Feature: OwnerPropertyServices
	Owner property services on owned properties

@mytag
Scenario: As an owner I want to request for To Whom It May concern certificate
Given that I am on Dubailand website
	And I Press Sign In button
	And I navigate to Signin Page
	And I select Owner Login option
	And I Enter enter valid Owner Emirates ID 196314148139
	And I Enter valid Date of Birth 25-10-1963
	And I Press login button
	And I Press Continue button
	When I Enter valid Passcode 59062
	And I Press Verify button
	Then Owner is logged In
	Then I verify owner name is Yasser Ihsan Alhayek
	And I Click on To Whom It May Concern service
	Then I navigate to To Whom It May Concern service page
	And I Click on Continue button
	Then I verify fee details total is 70.00 AED
	And I Click Pay button
	When I choose Noqodi payment method
	Then I navigate to Noqodi payment details page
	And I enter Noqodi username that is dw100029
	And I enter Password that is P@ss1234
	When I click on Login button
	Then user is logged in
	And I click on Pay button
	Then I verify transaction is completed
	
	Scenario: As an Owner I want to verify my property details
	Given that I am on Dubailand website
	And I Press Sign In button
	And I navigate to Signin Page
	And I select Owner Login option
	And I Enter enter valid Owner Emirates ID 196314148139
	And I Enter valid Date of Birth 25-10-1963
	And I Press login button
	And I Press Continue button
	When I Enter valid Passcode 59062
	And I Press Verify button
	Then Owner is logged In
	Then I verify owner name is Yasser Ihsan Alhayek 
	Then I verify property count is 2
	When I click on View All button
	Then list of owned properties appear
	When I Click on property details button
	Then property details appear
	Then I verify Land number is 664-359
	Then I verify Area is Wadi Al Safa 6
	Then I verify Size is 631.18
	Then I verify Land Type is Residential
	Then I verify ownership is 100.00 %
	Then I verify property granted is No
	Then I verify property status is Leased_To_Own
	Then I verify Property is Free Hold



	
