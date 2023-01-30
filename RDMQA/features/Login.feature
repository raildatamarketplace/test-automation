Feature: RDM_Login

A short summary of the feature

@login
Scenario: Successful login - RDM Admin
	Given I am on the login page
	And I have entered "test.RDMadminLiam" in the username field
	And I have entered "TestPassword123$" in the password field
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login
Scenario: Successful login - Org Admin
	Given I am on the login page
	And I have entered "test.LNAdmin" in the username field
	And I have entered "TestPassword123$" in the password field
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login
Scenario: Successful login - Publisher
	Given I am on the login page
	And I have entered "test.LNPublisher" in the username field
	And I have entered "TestPassword123$" in the password field
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login
Scenario: Successful login - Consumer
	Given I am on the login page
	And I have entered "test.LNConsumer" in the username field
	And I have entered "TestPassword123$" in the password field
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login
Scenario: Successful login - FinanciallyAuthorisedConsumer
	Given I am on the login page
	And I have entered "test.LNFAC" in the username field
	And I have entered "TestPassword123$" in the password field
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login
Scenario: Successful login - FinanceApprover
	Given I am on the login page
	And I have entered "test.FinanceApprover" in the username field
	And I have entered "TestPassword123$" in the password field
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login @logout
Scenario: Login and Logout
	Given I am on the login page
	And I have entered "test.FinanceApprover" in the username field
	And I have entered "TestPassword123$" in the password field
	When I click the login button
	And I wait for 3 seconds
	And I have logged out
	Then I should be taken to the access homepage


