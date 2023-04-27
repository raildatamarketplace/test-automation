Feature: RDM_Login

A short summary of the feature

@login @preprod
Scenario: Successful login - RDM Admin - PreProd
	Given I am on the login page
	And I have entered "PreProd.LNRDMAdmin" in the username field
	And I have entered "TestPassword123$" in the password field
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login @preprod @ignore
Scenario: Successful login - Org Admin - PreProd
	Given I am on the login page
	And I have entered "PreProd.LNAdmin" in the username field
	And I have entered "TestPassword123$" in the password field
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login @preprod @ignore
Scenario: Successful login - Publisher - PreProd
	Given I am on the login page
	And I have entered "PreProd.LNPublisher" in the username field
	And I have entered "TestPassword123$" in the password field
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login @preprod @ignore
Scenario: Successful login - Consumer - PreProd
	Given I am on the login page
	And I have entered "PreProd.LNConsumer" in the username field
	And I have entered "TestPassword123$" in the password field
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login @preprod @ignore
Scenario: Successful login - FinanciallyAuthorisedConsumer - PreProd
	Given I am on the login page
	And I have entered "PreProd.LNFAC" in the username field
	And I have entered "TestPassword123$" in the password field
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login @preprod @ignore
Scenario: Successful login - FinanceApprover - PreProd
	Given I am on the login page
	And I have entered "PreProd.FinanceApprover" in the username field
	And I have entered "TestPassword123$" in the password field
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login @test
Scenario: Successful login - RDM Admin - Test
	Given I am on the login page
	And I have entered "test.RDMadminLiam" in the username field
	And I have entered "TestPassword123$" in the password field
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login @test
Scenario: Successful login - Org Admin - Test
	Given I am on the login page
	And I have entered "test.LNAdmin" in the username field
	And I have entered "TestPassword123$" in the password field
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login @test
Scenario: Successful login - Publisher - Test
	Given I am on the login page
	And I have entered "test.LNPublisher" in the username field
	And I have entered "TestPassword123$" in the password field
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login @test
Scenario: Successful login - Consumer - Test
	Given I am on the login page
	And I have entered "test.LNConsumer" in the username field
	And I have entered "TestPassword123$" in the password field
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login @test
Scenario: Successful login - FinanciallyAuthorisedConsumer - Test
	Given I am on the login page
	And I have entered "test.LNFAC" in the username field
	And I have entered "TestPassword123$" in the password field
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login @test
Scenario: Successful login - FinanceApprover - Test
	Given I am on the login page
	And I have entered "test.FinanceApprover" in the username field
	And I have entered "TestPassword123$" in the password field
	When I click the login button
	And I wait for 3 seconds
	Then I should be taken to the dashboard homepage

@login @logout @preprod @ignore
Scenario: Login and Logout - PreProd
	Given I am on the login page
	And I have entered "PreProd.FinanceApprover" in the username field
	And I have entered "TestPassword123$" in the password field
	When I click the login button
	And I wait for 3 seconds
	And I have logged out
	Then I should be taken to the access homepage

@login @logout @test
Scenario: Login and Logout - Test
	Given I am on the login page
	And I have entered "test.FinanceApprover" in the username field
	And I have entered "TestPassword123$" in the password field
	When I click the login button
	And I wait for 3 seconds
	And I have logged out
	Then I should be taken to the access homepage


