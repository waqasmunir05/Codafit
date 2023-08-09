Feature: Login as Business Users

This feature is to verify Business user login cases on Dubailand website
@tag1
Scenario: Login as Trakheesi Admin on Dubailand website with username and password
	Given that I am on Dubailand website
	And I Press Sign In button
	# And I navigate to Signin Page
	And I select Business user as Login option
	And I select Username and Password as Login option
	Then I enter Username as rasheedt
	Then I enter Password as 12345
	When I Click Login button
	Then I am successfully logged in to Dubailand Dashboard

	Scenario: Login as Trakheesi Company on Dubailand website with username and password
	Given that I am on Dubailand website
	And I Press Sign In button
	# And I navigate to Signin Page
	And I select Business user as Login option
	And I select Username and Password as Login option
	Then I enter Username as 777properties
	Then I enter Password as 12345
	When I Click Login button
	Then I am successfully logged in to Dubailand Dashboard

	Scenario: Login as RVS employee on Dubailand website with username and password
	Given that I am on Dubailand website
	And I Press Sign In button
	# And I navigate to Signin Page
	And I select Business user as Login option
	And I select Username and Password as Login option
	Then I enter Username as sradmin
	Then I enter Password as 12345
	When I Click Login button
	Then I am successfully logged in to Dubailand Dashboard

	Scenario: Redirect Trakheesi admin to Trakheesi application
	Given that I am on Dubailand website
	And I Press Sign In button
	# And I navigate to Signin Page
	And I select Business user as Login option
	And I select Username and Password as Login option
	Then I enter Username as rasheedt
	Then I enter Password as 12345
	When I Click Login button
	Then I am successfully logged in to Dubailand Dashboard
	When I click on Go to Account button
	Then user is redirect to Trakheesi application successfully

	Scenario: Redirect Trakheesi Company admin to Trakheesi application
	Given that I am on Dubailand website
	And I Press Sign In button
	# And I navigate to Signin Page
	And I select Business user as Login option
	And I select Username and Password as Login option
	Then I enter Username as 777properties
	Then I enter Password as 12345
	When I Click Login button
	Then I am successfully logged in to Dubailand Dashboard
	When I click on Go to Account button
	Then Trakheesi Company user is redirect to Trakheesi application successfully

	Scenario: Redirect RVS Employee to RVS application
	Given that I am on Dubailand website
	And I Press Sign In button
	# And I navigate to Signin Page
	And I select Business user as Login option
	And I select Username and Password as Login option
	Then I enter Username as sradmin
	Then I enter Password as 12345
	When I Click Login button
	Then I am successfully logged in to Dubailand Dashboard
	When I click on Go to Account button
	Then RVS employee user is redirect to RVS application successfully

	Scenario: Redirect Ejari Management Company to Ejari application
	Given that I am on Dubailand website
	And I Press Sign In button
	# And I navigate to Signin Page
	And I select Business user as Login option
	And I select Username and Password as Login option
	Then I enter Username as asteco123
	Then I enter Password as 12345
	When I Click Login button
	Then I am successfully logged in to Dubailand Dashboard
	When I click on Go to Account button
	Then Management Company user is redirect to Ejari application successfully