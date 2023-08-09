Feature: OwnerLoginWithEmiratesID
	Login on Dubailand website with Owner Emirates ID

@login
Scenario: Login to Dubailand website with valid Owner Emirates ID
	Given that I am on Dubailand website
	And I Press Sign In button
	# And I navigate to Signin Page
	And I select Owner Login option
	And I Enter enter valid Owner Emirates ID 198657419044
	And I Enter valid Date of Birth 01-02-1981
	And I Press login button
	And I Press Continue button
	When I Enter valid Passcode 58026
	And I Press Verify button
	Then Owner is logged In
	Then I verify owner name is Muhammad Ali Rasheed Abdul Rasheed Chaudhry
	Then I verify email is waqas.munir@eres.ae
	Then I verify mobile is 971558895363
	Then I verify emiratesid is 784198657419044
	And I Click on Logout button
	When I click confirm logout button
	Then user is logged out

	

Scenario: Login to Dubailand website with valid owner Mobile
	Given that I am on Dubailand website
	And I Press Sign In button
	#And I navigate to Signin Page
	And I select Owner Login option
	And I select Mobile login option
	And I Enter valid owner mobile number 558895363
	And I Enter valid Date of Birth 01-02-1981
	And I Press login button
	And I Press Continue button
	When I Enter valid Passcode 51441
	And I Press Verify button
	Then Owner is logged In
	Then I verify owner name is Muhammad Ali Rasheed Abdul Rasheed Chaudhry
	Then I verify email is waqas.munir@eres.ae
	Then I verify mobile is 971558895363
	Then I verify emiratesid is 784198657419044
	And I Click on Logout button
	When I click confirm logout button
	Then user is logged out

Scenario: Login to Dubailand website with valid Title Deed
	Given that I am on Dubailand website
	And I Press Sign In button
	#And I navigate to Signin Page
	And I select Owner Login option
	And I select Title Deed option
	And I enter Certificate number 63336
	And I select certificate issue date 01-01-2021
	And I enter owner number 4935708
	And I Enter valid Date of Birth 01-02-1981
	And I Press login button
	And I Press Continue button
	When I Enter valid Passcode 13631
	And I Press Verify button
	Then Owner is logged In
	Then I verify owner name is Muhammad Ali Rasheed Abdul Rasheed Chaudhry
	Then I verify email is waqas.munir@eres.ae
	Then I verify mobile is 971558895363
	Then I verify emiratesid is 784198657419044
	And I Click on Logout button
	When I click confirm logout button
	Then user is logged out

Scenario: Log out as owner from Dubailand website
	Given that I am on Dubailand website
	And I Press Sign In button
	#And I navigate to Signin Page
	And I select Owner Login option
	And I Enter enter valid Owner Emirates ID 198172792107
	And I Enter valid Date of Birth 01-02-1981
	And I Press login button
	And I Press Continue button
	When I Enter valid Passcode 13631
	And I Press Verify button
	Then Owner is logged In
	And I Click on Logout button
	When I click confirm logout button
	Then user is logged out

	

Scenario: Unsuccessful login with invalid emiratesid
	Given that I am on Dubailand website
	And I Press Sign In button
	#And I navigate to Signin Page
	And I select Owner Login option
	And I Enter enter valid Owner Emirates ID 198657419040
	And I Enter valid Date of Birth 06-06-1959
	And I Press login button
	Then error message displayed with user not found
	
Scenario: Unsuccessful login with invalid mobile number
	Given that I am on Dubailand website
	And I Press Sign In button
	#And I navigate to Signin Page
	And I select Owner Login option
	And I select Mobile login option
	And I Enter valid owner mobile number 558895362
	And I Enter valid Date of Birth 06-06-1959
	And I Press login button
	Then error message displayed with user not found