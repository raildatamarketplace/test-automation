Feature: RDM_Login

A short summary of the feature

@login @preprod 
Scenario: Successful login - RDM Admin - PreProd
	Given I am on the login page
	And I have logged in as "RDMAdmin" user
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login @preprod 
Scenario: Successful login - Org Admin - PreProd
	Given I am on the login page
	And I have logged in as "Admin" user
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login @preprod 
Scenario: Successful login - Publisher - PreProd
	Given I am on the login page
	And I have logged in as "Publisher" user
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login @preprod 
Scenario: Successful login - Consumer - PreProd
	Given I am on the login page
	And I have logged in as "Consumer" user
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login @preprod 
Scenario: Successful login - FAConsumer - PreProd
	Given I am on the login page
	And I have logged in as "FAConsumer" user
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login @preprod 
Scenario: Successful login - FinanceApprover - PreProd
	Given I am on the login page
	And I have logged in as "FinanceApprover" user
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login @preprod 
Scenario: Successful login - ContentManager - PreProd
	Given I am on the login page
	And I have logged in as "ContentManager" user
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login @logout @preprod 
Scenario: Login and Logout - PreProd
	Given I am on the login page
	And I have logged in as "Admin" user
	When I click the login button
	And I wait for 3 seconds
	And I have logged out
	Then I should be taken to the access homepage



